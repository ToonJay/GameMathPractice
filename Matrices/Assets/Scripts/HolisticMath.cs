using UnityEngine;

public class HolisticMath {
    static public float Square(float value) {
        return value * value;
    }

    static public float Distance(Coords point1, Coords point2) {
        return Mathf.Sqrt(
            Square(point2.x - point1.x) +
            Square(point2.y - point1.y) +
            Square(point2.z - point1.z)
            );
    }

    static public Coords Lerp(Coords A, Coords B, float t) {
        t = Mathf.Clamp01(t);
        return A + (B - A) * t;
    }

    static public Coords GetNormal(Coords vector) {
        float length = Distance(new Coords(), vector);
        return vector / length;
    }

    static public float Dot(Coords vector1, Coords vector2) {
        return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
    }

    static public Coords Cross(Coords vector1, Coords vector2) {
        return new Coords(
            vector1.y * vector2.z - vector1.z * vector2.y,
            vector1.z * vector2.x - vector1.x * vector2.z,
            vector1.x * vector2.y - vector1.y * vector2.x
            );
    }

    static public float Angle(Coords vector1, Coords vector2) {
        return Mathf.Acos(
            Dot(vector1, vector2) / 
            (Distance(new Coords(), vector1) * Distance(new Coords(), vector2))
            ); // radians. * 180 / PI for degrees
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise = true) { // in radians
        if (clockwise) {
            angle = -angle;
        }
        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        
        return new Coords(xVal, yVal);
    }

    static public Coords Translate(Coords position, Coords forwardVector, Coords vector) {
        if (Distance(new Coords(), vector) <= 0) {
            return position;
        }
        float angle = Angle(vector, forwardVector);
        float worldAngle = Angle(vector, new Coords(0, 1, 0));
        bool clockwise = false;
        if (Cross(vector, forwardVector).z < 0) {
            clockwise = true;
        }
        vector = Rotate(vector, angle + worldAngle, clockwise);
        position += vector;

        return position;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint) {
        Coords direction = focusPoint - position;
        float angle = Angle(forwardVector, direction);
        bool clockwise = false;
        if (Cross(forwardVector, direction).z < 0) {
            clockwise = true;
        }

        return Rotate(forwardVector, angle, clockwise);
    }

    static public Coords Translate(Coords position, Coords vector) {
        float[] translationValues = { 1, 0, 0, vector.x,
                                      0, 1, 0, vector.y,
                                      0, 0, 1, vector.z,
                                      0, 0, 0, 1 };
        Matrix translationMatrix = new Matrix(4, 4, translationValues);
        Matrix positionMatrix = new Matrix(4, 1, position.AsFloats());
        Matrix resultMatrix = translationMatrix * positionMatrix;

        return resultMatrix.AsCoords();
    }

    static public Coords Scale(Coords position, float scaleX, float scaleY, float scaleZ) {
        float[] scalingValues = { scaleX, 0, 0, 0,
                                  0, scaleY, 0, 0,
                                  0, 0, scaleZ, 0,
                                  0, 0, 0, 1 };
        Matrix scalingMatrix = new Matrix(4, 4, scalingValues);
        Matrix positionMatrix = new Matrix(4, 1, position.AsFloats());
        Matrix resultMatrix = scalingMatrix * positionMatrix;

        return resultMatrix.AsCoords();
    }

    static public Coords Rotate(Coords position, float angleX, bool clockwiseX,
                                                 float angleY, bool clockwiseY,
                                                 float angleZ, bool clockwiseZ) {
        if (!clockwiseX) {
            angleX = -angleX;
        }
        Matrix Pitch = new Matrix(4, 4, new float[] { 1, 0, 0, 0,
                                                      0, Mathf.Cos(angleX), -Mathf.Sin(angleX), 0,
                                                      0, Mathf.Sin(angleX), Mathf.Cos(angleX), 0,
                                                      0, 0, 0, 1 });
        if (!clockwiseY) {
            angleY = -angleY;
        }
        Matrix Yaw = new Matrix(4, 4, new float[] { Mathf.Cos(angleY), 0, Mathf.Sin(angleY), 0,
                                                    0, 1, 0, 0,
                                                    -Mathf.Sin(angleY), 0, Mathf.Cos(angleY), 0,
                                                    0, 0, 0, 1 });
        if (!clockwiseZ) {
            angleZ = -angleZ;
        }
        Matrix Roll = new Matrix(4, 4, new float[] { Mathf.Cos(angleZ), -Mathf.Sin(angleZ), 0, 0,
                                                     Mathf.Sin(angleZ), Mathf.Cos(angleZ), 0, 0,
                                                     0, 0, 1, 0,
                                                     0, 0, 0, 1 });
        Matrix positionMatrix = new Matrix(4, 1, position.AsFloats());
        Matrix resultMatrix = Roll * Yaw * Pitch * positionMatrix;

        return resultMatrix.AsCoords();
    }

    static public Matrix GetRotationMatrix(float angleX, bool clockwiseX,
                                           float angleY, bool clockwiseY,
                                           float angleZ, bool clockwiseZ) {
        if (!clockwiseX) {
            angleX = -angleX;
        }
        Matrix Pitch = new Matrix(4, 4, new float[] { 1, 0, 0, 0,
                                                      0, Mathf.Cos(angleX), -Mathf.Sin(angleX), 0,
                                                      0, Mathf.Sin(angleX), Mathf.Cos(angleX), 0,
                                                      0, 0, 0, 1 });
        if (!clockwiseY) {
            angleY = -angleY;
        }
        Matrix Yaw = new Matrix(4, 4, new float[] { Mathf.Cos(angleY), 0, Mathf.Sin(angleY), 0,
                                                    0, 1, 0, 0,
                                                    -Mathf.Sin(angleY), 0, Mathf.Cos(angleY), 0,
                                                    0, 0, 0, 1 });
        if (!clockwiseZ) {
            angleZ = -angleZ;
        }
        Matrix Roll = new Matrix(4, 4, new float[] { Mathf.Cos(angleZ), -Mathf.Sin(angleZ), 0, 0,
                                                     Mathf.Sin(angleZ), Mathf.Cos(angleZ), 0, 0,
                                                     0, 0, 1, 0,
                                                     0, 0, 0, 1 });
        Matrix rotationMatrix = Roll * Yaw * Pitch;

        return rotationMatrix;
    }

    static public float GetRotationAxisAngle(Matrix rotation) {
        return Mathf.Acos(
                (
                rotation.GetValue(0, 0) +
                rotation.GetValue(1, 1) +
                rotation.GetValue(2, 2) +
                rotation.GetValue(3, 3) -
                2
                ) / 2
            );
    }

    static public Coords GetRotationAxis(Matrix rotation, float angle) {
        float Ax = (rotation.GetValue(2, 1) - rotation.GetValue(1, 2)) / (2 * Mathf.Sin(angle));
        float Ay = (rotation.GetValue(0, 2) - rotation.GetValue(2, 0)) / (2 * Mathf.Sin(angle));
        float Az = (rotation.GetValue(1, 0) - rotation.GetValue(0, 1)) / (2 * Mathf.Sin(angle));
        return new Coords(Ax, Ay, Az, 0);
    }

    static public Coords Shear(Coords position, float shearXY, float shearXZ, float shearYX, float shearYZ, float shearZX, float shearZY) {
        Matrix shearingMatrix = new Matrix(4, 4, new float[] { 1, shearXY, shearXZ, 0,
                                                               shearYX, 1, shearYZ, 0,
                                                               shearZX, shearZY, 1, 0,
                                                               0, 0, 0, 1 });
        Matrix positionMatrix = new Matrix(4, 1, position.AsFloats());
        Matrix resultMatrix = shearingMatrix * positionMatrix;

        return resultMatrix.AsCoords();
    }

    static public Coords ReflectX(Coords position) {
        Matrix reflectMatrix = new Matrix(4, 4, new float[] { -1, 0, 0, 0,
                                                               0, 1, 0, 0,
                                                               0, 0, 1, 0,
                                                               0, 0, 0, 1 });
        Matrix positionMatrix = new Matrix(4, 1, position.AsFloats());
        Matrix resultMatrix = reflectMatrix * positionMatrix;

        return resultMatrix.AsCoords();
    }

    static public Coords QRotate(Coords position, Coords axis, float angle /*in degrees*/, bool clockwise = true) {

        Coords axisNormal = GetNormal(axis);
        angle *= Mathf.Deg2Rad;
        if (!clockwise) {
            angle = -angle;
        }
        Coords v = axisNormal * Mathf.Sin(angle / 2);
        Coords q = new Coords(v.x, v.y, v.z, Mathf.Cos(angle / 2));
        float x = q.x; 
        float y = q.y; 
        float z = q.z; 
        float w = q.w;
        Matrix rotationMatrix = new Matrix(4, 4, new float[] { 1 - 2*Square(y) - 2*Square(z), 2*x*y - 2*w*z, 2*x*z + 2*w*y, 0,
                                                               2*x*y + 2*w*z, 1 - 2*Square(x) - 2*Square(z), 2*y*z - 2*w*x, 0,
                                                               2*x*z - 2*w*y, 2*y*z + 2*w*x, 1 - 2*Square(x) - 2*Square(y), 0,
                                                               0, 0, 0, 1 });
        Matrix positionMatrix = new Matrix(4, 1, position.AsFloats());
        Matrix resultMatrix = rotationMatrix * positionMatrix;

        return resultMatrix.AsCoords();
    }
}