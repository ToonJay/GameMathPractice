using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //transform.Translate(0, translation, 0);

        this.transform.position = HolisticMath.Translate(new Coords(this.transform.position), new Coords(this.transform.up), new Coords(0, translation, 0)).ToVector();

        //transform.Rotate(0, 0, -rotation);
        bool clockwise = false;
        if (translation < 0) {
            clockwise = true;
        }
        this.transform.up = HolisticMath.Rotate(new Coords(this.transform.up), -rotation / 180 * Mathf.PI, clockwise).ToVector();
    }
}
