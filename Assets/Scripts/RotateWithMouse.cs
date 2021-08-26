using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public float speedRotate;
    public float rotateX, rotateY;
    public InputManager inputManager;
    public Quaternion rotationY;
    public Vector2 limitsY;

    float x, y;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    
    void Update()
    {
        float mouseX = -inputManager.horizontalMouse;
        float mouseY = inputManager.verticalMouse;
        x = mouseX * rotateX;
        y = mouseY * rotateY;
        transform.eulerAngles += speedRotate * new Vector3(x, y, 0);
        //transform.eulerAngles += speedRotate * new Vector3(x*0.1f, y, 0);
        return;
    }
}
