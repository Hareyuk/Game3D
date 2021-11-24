using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : InteractiveObj
{
    public float numberCorrect;
    public bool isCorrect;
    public Door door;
    bool isAlreadyPressed = false;
    public Material normal;
    public Material pressed;
    public Material correct;

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
                /*GetComponent<Renderer>().material.color = new Color(80f, 0f, 0f);
                GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(255F, 0f, 0f, 1F));*/
                GetComponent<Renderer>().material = pressed;
                door.numberButtonsFloor++;
                door.checkButtonsFloor();
            }
            base.OnSomethingEnter(go);
        }
    }

    public void RestartFloorButton()
    {
        isCorrect = false;
        /* GetComponent<Renderer>().material.color = new Color(255, 255, 255);
         GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0f, 0f, 0f, 1F));*/
        GetComponent<Renderer>().material = normal;
        isAlreadyPressed = false;
    }
}
