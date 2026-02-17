using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    Plane plane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = new Plane(
            new Coords(A.transform.position),
            new Coords(B.transform.position),
            new Coords(C.transform.position)
            );

        for (float s = 0; s < 1; s += 0.1f) {
            for (float t = 0; t < 1; t += 0.1f) {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s, t).ToVector();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
