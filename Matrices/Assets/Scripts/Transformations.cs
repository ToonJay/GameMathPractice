using Unity.VisualScripting;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public GameObject center;
    public Vector3 rotation;
    public Vector3 translation;
    public Vector3 scaling;
    public Vector3 shearingX;
    public Vector3 shearingY;
    public Vector3 shearingZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 centrePoint = center.transform.position;
        rotation *= Mathf.Deg2Rad;

        foreach (GameObject p in points) {
            Coords position = new Coords(p.transform.position, 1);
            //position = HolisticMath.Translate(position, new Coords(-centrePoint, 0));
            //position = HolisticMath.Rotate(position, rotation.x, true, rotation.y, true, rotation.z, true);
            //p.transform.position = HolisticMath.Translate(position, new Coords(centrePoint, 0)).ToVector();

            //p.transform.position = HolisticMath.Translate(position, new Coords(translation, 0)).ToVector();

            //position = HolisticMath.Translate(position, new Coords(-centrePoint, 0));
            //position = HolisticMath.Scale(position, scaling.x, scaling.y, scaling.z);
            //p.transform.position = HolisticMath.Translate(position, new Coords(centrePoint, 0)).ToVector();

            //p.transform.position = HolisticMath.Shear(position, shearingX.y, shearingX.z, shearingY.x, shearingY.z, shearingZ.x, shearingZ.y).ToVector();

            //p.transform.position = HolisticMath.ReflectX(position).ToVector();
        }
        
        Coords.DrawLine(new Coords(points[0].transform.position), new Coords(points[1].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[1].transform.position), new Coords(points[2].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[2].transform.position), new Coords(points[3].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[3].transform.position), new Coords(points[0].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[0].transform.position), new Coords(points[4].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[1].transform.position), new Coords(points[5].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[2].transform.position), new Coords(points[6].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[3].transform.position), new Coords(points[7].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[4].transform.position), new Coords(points[5].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[5].transform.position), new Coords(points[6].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[6].transform.position), new Coords(points[7].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[7].transform.position), new Coords(points[4].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[2].transform.position), new Coords(points[9].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[3].transform.position), new Coords(points[8].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[6].transform.position), new Coords(points[9].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[7].transform.position), new Coords(points[8].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[8].transform.position), new Coords(points[9].transform.position), 0.05f, Color.yellow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnValidate() {
        shearingX.x = 0;
        shearingY.y = 0;
        shearingZ.z = 0;
    }
}
