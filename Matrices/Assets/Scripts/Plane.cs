using UnityEngine;

public class Plane
{
    public Coords A;
    public Coords B;
    public Coords C;
    public Coords v;
    public Coords u;

    public Plane(Coords A, Coords B, Coords C) {
        this.A = A; 
        this.B = B; 
        this.C = C;
        v = B - A;
        u = C - A;
    }

    public Plane(Coords A, Vector3 v, Vector3 u) {
        this.A = A;
        this.v = new Coords(v);
        this.u = new Coords(u);
    }

    public Coords Lerp(float s, float t) {
        return A + v * s + u * t;
    }
}
