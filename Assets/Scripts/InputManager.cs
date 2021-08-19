using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float verticalAxis;
    public float horizontalAxis;
    public bool buttonSkill;
    public float verticalMouse;
    public float horizontalMouse;
    public bool isMovingY, isMovingX;
    public bool isRunning;
    public bool pressingMouseLeftButton;
    public float axisMouse;
    //Acceder por ID
    void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");
        buttonSkill = Input.GetButtonDown("ButtonAction");
        verticalMouse = Input.GetAxis("Mouse X");
        horizontalMouse = Input.GetAxis("Mouse Y");
        isMovingX = Input.GetButton("Horizontal");
        isMovingY = Input.GetButton("Vertical");
        isRunning = Input.GetButton("Run");
        pressingMouseLeftButton = Input.GetMouseButtonDown(0);
        axisMouse = Input.GetAxis("Mouse ScrollWheel");
    }
}
