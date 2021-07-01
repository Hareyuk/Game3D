using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float verticalAxis;
    public float horizontalAxis;
    public bool buttonSkill;
    //Acceder por ID
    void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");
        buttonSkill = Input.GetMouseButtonDown(0);
    }
}
