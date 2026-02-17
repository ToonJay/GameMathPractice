using Unity.VisualScripting;
using UnityEngine;

public class Line
{
    public Coords A;
    public Coords B;
    public Coords v;

    public enum LINETYPE {LINE, SEGMENT, RAY};
    LINETYPE type;

    public Line(Coords A, Coords B, LINETYPE type) {
        this.A = A; 
        this.B = B;
        this.type = type;
        v = B - A;
    }

    public Line(Coords A, Coords v) {
        this.A = A;
        this.v = v; 
        B = A + v;
        type = LINETYPE.SEGMENT; 
    }

    public void Draw(float width, Color color) {
        Coords.DrawLine(A, B, width, color);
    }

    public Coords Lerp(float t) {
        if (type == LINETYPE.SEGMENT) {
            t = Mathf.Clamp01(t);
        } else if(type == LINETYPE.RAY) {
            t = Mathf.Max(0, t);
        }

        return A + v * t;
    }
}
