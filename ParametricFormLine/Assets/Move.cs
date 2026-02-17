using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start;
    public Transform end;
    //Line line;
    //[Range(-2f, 2f)]
    //public float t = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //line = new Line(new Coords(start.position), new Coords(end.position), Line.LINETYPE.SEGMENT);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = line.Lerp(t).ToVector();
        //this.transform.position = HolisticMath.Lerp(
        //    new Coords(start.transform.position),
        //    new Coords(end.transform.position),
        //    t
        //    ).ToVector();

        //this.transform.position = line.Lerp(Time.time * 0.1f).ToVector();
        this.transform.position = HolisticMath.Lerp(
            new Coords(start.transform.position),
            new Coords(end.transform.position),
            Time.time * 0.1f
            ).ToVector();
    }
}
