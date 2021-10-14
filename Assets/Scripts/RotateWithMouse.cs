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
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            float mouseX = -inputManager.horizontalMouse;
            float mouseY = inputManager.verticalMouse;
            x = mouseX * rotateX;
            y = mouseY * rotateY;
            transform.eulerAngles += Time.deltaTime * speedRotate * new Vector3(x, y, 0);
            //transform.Rotate(speedRotate * new Vector3(x, 0, y));
            //transform.eulerAngles += speedRotate * new Vector3(x*0.1f, y, 0);
        }
    }
}
