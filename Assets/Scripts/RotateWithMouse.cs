using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public Vector3 initialCamera;
    public float speedRotate;
    public float rotateX, rotateY;
    public InputManager inputManager;

    [SerializeField]
    Vector3 cameraVector;

    float x, y;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if(tag == "MainCamera")
        {
            transform.localEulerAngles = initialCamera;
        }
    }

    
    void Update()
    {
        cameraVector = transform.localEulerAngles;
        float mouseX = -inputManager.horizontalMouse;
        float mouseY = inputManager.verticalMouse;
        x = mouseX * rotateX;
        y = mouseY * rotateY; 
        transform.eulerAngles += speedRotate * new Vector3(x*0.1f, y, 0);
        if (rotateX == 1)
        {
            float angleX = transform.eulerAngles.x;
            print(angleX); return;
            if (angleX < 340 && angleX > 300)
            {
                x = 0;
                transform.eulerAngles = new Vector3(340.001f, transform.eulerAngles.y, 0);
            }
            else if (angleX > 50)
            {
                x = 0;
                transform.rotation = Quaternion.Euler(49.99f, transform.eulerAngles.y, 0);
            }
        }
    }
}
