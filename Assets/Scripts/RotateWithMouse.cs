using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public float speedRotate;
    public float rotateX, rotateY;
    float x, y;
    void Start()
    {
        Cursor.visible = false;
        x = 20;
        y = 0;
    }
    void Update()
    {
        x = -Input.GetAxis("Mouse Y") * rotateX;
        y = Input.GetAxis("Mouse X") * rotateY; 
        //print("x: " +x + " - y: " + y);
        float angleX = transform.eulerAngles.x;
        if (angleX < -5 && rotateX == 1)
        {
            x = 0;
            transform.eulerAngles = new Vector3(-5, transform.eulerAngles.y, 0);
        }
        if (angleX > 40 && rotateX == 1)
        {
            //x = -(angleX - 40);
            x = 0;
            transform.eulerAngles = new Vector3(40, transform.eulerAngles.y, 0);
        }

        //transform.eulerAngles += speedRotate * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        transform.eulerAngles += speedRotate * new Vector3(x, y, 0);
        
    }
}
