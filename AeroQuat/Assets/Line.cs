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

    public Coords Reflect(Coords normal) {
        
        Coords n = HolisticMath.GetNormal(normal);
        Coords a = HolisticMath.GetNormal(v);
        if (HolisticMath.Dot(n, a) == 0) {
            return v;
        }

        return a - n * 2 * HolisticMath.Dot(a, n);
    }

    public float IntersectsAt(Line l) {
        if (HolisticMath.Dot(Coords.Perp(l.v), v) == 0) { 
            return float.NaN; 
        }
        float t = HolisticMath.Dot(Coords.Perp(l.v), (l.A - A)) / HolisticMath.Dot(Coords.Perp(l.v), v);
        if ((t < 0 || t > 1) && type == LINETYPE.SEGMENT) {
            return float.NaN;
        }
        return t;  
    }

    public float IntersectsAt(Plane p) {
        Coords n = HolisticMath.Cross(p.u, p.v);
        if (HolisticMath.Dot(n, v) == 0) {
            return float.NaN;
        }
        return HolisticMath.Dot(n - n * 2, A - p.A) / HolisticMath.Dot(n, v);
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
