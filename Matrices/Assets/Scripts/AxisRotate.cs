using UnityEngine;

public class AxisRotate : MonoBehaviour
{
    public GameObject[] points;
    public Vector3 angles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        angles *= Mathf.Deg2Rad;
        foreach (GameObject p in points) {
            Coords position = new Coords(p.transform.position, 1);
            p.transform.position = HolisticMath.Rotate(position, angles.x, true, angles.y, true, angles.z, true).ToVector();
        }

        Matrix rotation = HolisticMath.GetRotationMatrix(angles.x, true, angles.y, true, angles.z, true);
        float axisAngle = HolisticMath.GetRotationAxisAngle(rotation);
        Coords axis = HolisticMath.GetRotationAxis(rotation, axisAngle);

        Debug.Log("Quaternion Equivalent: " + axisAngle * Mathf.Rad2Deg + " about " + axis);
        Coords.DrawLine(new Coords(), axis * 5, 0.1f, Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
