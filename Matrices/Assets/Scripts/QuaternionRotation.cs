using UnityEngine;

public class QuaternionRotation : MonoBehaviour
{
    public GameObject[] points;
    public float angle;
    public Vector3 axis;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject p in points) {
            Coords position = new Coords(p.transform.position, 1);
            Coords A = new Coords(axis, 0);
            p.transform.position = HolisticMath.QRotate(position, A, angle).ToVector();
        }
        Coords.DrawLine(new Coords(), new Coords(axis) * 3, 0.1f, Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        foreach (GameObject p in points) {
           Coords position = new Coords(p.transform.position, 1);
            Coords A = new Coords(axis, 0);
            p.transform.position = HolisticMath.QRotate(position, A, 1f).ToVector();
        }
        */
    }
}
