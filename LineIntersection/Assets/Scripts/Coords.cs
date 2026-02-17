using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords {

    public float x;
    public float y;
    public float z;

    public Coords() {
        x = 0;
        y = 0;
        z = 0;
    }

    public Coords(float x, float y)
    {
        this.x = x;
        this.y = y;
        z = 0;
    }

    public Coords(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Coords(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "," + z +")";
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }

    static public Coords operator+(Coords left, Coords right) {
        return new Coords(left.x + right.x, left.y + right.y, left.z + right.z);
    }

    static public Coords operator-(Coords left, Coords right) {
        return new Coords(left.x - right.x, left.y - right.y, left.z - right.z);
    }

    static public Coords operator*(Coords left, float right) {
        return new Coords(left.x * right, left.y * right, left.z * right);
    }

    static public Coords operator/(Coords left, float right) {
        return new Coords(left.x / right, left.y / right, left.z / right);
    }

    static public Coords Perp(Coords v) {
        return new Coords(-v.y, v.x);
    }

    static public void DrawLine(Coords startPoint, Coords endPoint, float width, Color colour)
    {
        GameObject line = new GameObject("Line_" + startPoint.ToString() + "_" + endPoint.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = colour;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(startPoint.x, startPoint.y, startPoint.z));
        lineRenderer.SetPosition(1, new Vector3(endPoint.x, endPoint.y, endPoint.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

    static public void DrawPoint(Coords position, float width, Color colour)
    {
        GameObject line = new GameObject("Point_" + position.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = colour;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(position.x - width / 3.0f, position.y - width / 3.0f, position.z));
        lineRenderer.SetPosition(1, new Vector3(position.x + width / 3.0f, position.y + width / 3.0f, position.z));
        lineRenderer.startWidth = width;
        lineRenderer.endWidth = width;
    }

}
