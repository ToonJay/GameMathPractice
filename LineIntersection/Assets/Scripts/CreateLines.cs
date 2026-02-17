using UnityEngine;

public class CreateLines : MonoBehaviour
{
    Line L1;
    Line L2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        L1 = new Line(new Coords(-100, 0), new Coords(20, 50));
        L1.Draw(1, Color.green);
        L2 = new Line(new Coords(-100, 10), new Coords(0, 50));
        L2.Draw(1, Color.red);
        float intersectT = L1.IntersectsAt(L2);
        float intersectS = L2.IntersectsAt(L1);
        if (!float.IsNaN(intersectT) && !float.IsNaN(intersectS)) {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = L1.Lerp(intersectT).ToVector();
        }
        Debug.Log("T:" + intersectT + " S:" + intersectS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
