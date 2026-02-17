using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float[] values = {1, 2, 3, 4, 5, 6 };
        Matrix m = new Matrix(3, 2, values);
        Matrix m2 = new Matrix(3, 2, values);
        Matrix m3 = m + m2;
        Matrix m4 = new Matrix(2, 3, values);
        Matrix m5 = new Matrix(3, 2, values);
        Matrix m6 = m4 * m5;
        Debug.Log(m.ToString() + "\n" + m2.ToString() + "\n" + m3.ToString());
        Debug.Log(m4.ToString() + "\n" + m5.ToString() + "\n" + m6.ToString());


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
