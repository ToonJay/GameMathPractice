using UnityEngine;

public class CreateSolidWall : MonoBehaviour
{

    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;
    public Transform E;

    Plane wall;
    Line ballPath;
    public GameObject ball;
    Line trajectory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wall = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));

        ballPath = new Line(new Coords(D.position), new Coords(E.position), Line.LINETYPE.SEGMENT);
        ballPath.Draw(1, Color.green);

        ball.transform.position = ballPath.A.ToVector();
        
        for (float s = 0; s <= 1; s += 0.1f) {
            for (float t = 0; t <= 1; t += 0.1f) {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = wall.Lerp(s, t).ToVector();
            }
        }

        float intersectT = ballPath.IntersectsAt(wall);
        if (!float.IsNaN(intersectT)) {
            trajectory = new Line(ballPath.A, ballPath.Lerp(intersectT), Line.LINETYPE.SEGMENT);
        }

        Line n = new Line(ballPath.Lerp(intersectT), HolisticMath.Cross(wall.v, wall.u));
        n.Draw(1, Color.green);

        Line r = new Line(ballPath.Lerp(intersectT), trajectory.Reflect(HolisticMath.Cross(wall.v, wall.u)) * 1000);
        r.Draw(1, Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time <= 1) {
            ball.transform.position = trajectory.Lerp(Time.time).ToVector();
        } else {
            ball.transform.position += trajectory.Reflect(HolisticMath.Cross(wall.v, wall.u)).ToVector() * Time.deltaTime * 5;
        }
    }
}
