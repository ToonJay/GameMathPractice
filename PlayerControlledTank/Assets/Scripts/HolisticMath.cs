using TMPro;
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

    static public Coords Rotate(Coords vector, float angle, bool clockwise) { // in radians
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
}