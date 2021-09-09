using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : InteractiveObj
{
    public float numberCorrect;
    public bool isCorrect;
    public Door door;
    bool isAlreadyPressed = false;

    public bool IsCorrectNumber()
    {
        return isCorrect;
    }

    public override void OnSomethingEnter(GameObject go)
    {
        if(!isAlreadyPressed)
        {
            print("Algo entró");
            if (go.name == "DogPBR_Mine")
            {
                isAlreadyPressed = true;
                if (door.numberButtonsFloor == numberCorrect)
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                }
                GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                door.numberButtonsFloor++;
                door.checkButtonsFloor();
            }
            base.OnSomethingEnter(go);
        }
    }

    public void RestartFloorButton()
    {
        isCorrect = false;
        GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        isAlreadyPressed = false;
    }
}
