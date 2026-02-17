using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateE : MonoBehaviour
{
    public Vector3 eulerAngles;
    Matrix rotationMatrix;
    float angle;
    Coords axis;
    Coords q;

    void Start() {
        rotationMatrix = HolisticMath.GetRotationMatrix(
            eulerAngles.x * Mathf.Deg2Rad, true,
            eulerAngles.y * Mathf.Deg2Rad, true,
            eulerAngles.z * Mathf.Deg2Rad, true
            );
        angle = HolisticMath.GetRotationAxisAngle(rotationMatrix);
        axis = HolisticMath.GetRotationAxis(rotationMatrix, angle);
        q  = HolisticMath.Quaternion(axis, angle);
    }

    void Update()
    {
        /*this.transform.forward = HolisticMath.Rotate(new Coords(this.transform.forward, 0),
                                                    1 * Mathf.Deg2Rad, false,
                                                    1 * Mathf.Deg2Rad, false,
                                                    1 * Mathf.Deg2Rad, false).ToVector();*/

        this.transform.rotation *= new Quaternion(q.x, q.y, q.z, q.w);
    }
}
