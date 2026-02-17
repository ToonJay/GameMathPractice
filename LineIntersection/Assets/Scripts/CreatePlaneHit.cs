using UnityEngine;

public class CreatePlaneHit : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;
    public Transform E;

    Plane plane;
    Line L1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));

        L1 = new Line(new Coords(D.position), new Coords(E.position), Line.LINETYPE.SEGMENT);
        L1.Draw(1, Color.green);

        for (float s = 0; s <= 1; s += 0.1f) {
            for (float t = 0;  t <= 1; t += 0.1f) {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
            }
        }

        float intersectT = L1.IntersectsAt(plane);
        Debug.Log(intersectT);
        if (!float.IsNaN(intersectT)) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = L1.Lerp(intersectT).ToVector();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
