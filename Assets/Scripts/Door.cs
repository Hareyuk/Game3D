using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObj
{
    public Transform leftDoor;
    public Transform rightDoor;
    public List<SlotBox> listSlots;
    public List<FloorButton> listButtonsFloor;
    public float numberButtonsFloor = 1;
    public void checkButtonsFloor()
    {
        bool buttonsPressed = true;
        if(numberButtonsFloor > listButtonsFloor.Count)
        {
            foreach (FloorButton btn in listButtonsFloor)
            {
                if (btn.isCorrect != true)
                {
                    buttonsPressed = false;
                }
            }
            if (buttonsPressed)
            {
                OpenDoor();
            }
            else
            {
                numberButtonsFloor = 1;
                foreach (FloorButton btn in listButtonsFloor)
                {
                    btn.RestartFloorButton();
                }
            }
        }
        
    }

    public void checkSlots()
    {
        bool slotsPushed = true;
        foreach (SlotBox slot in listSlots)
        {
            if(slot.isPushed != true)
            {
                slotsPushed = false;
            }
        }
        if(slotsPushed)
        {
            foreach(SlotBox slot in listSlots)
            {
                slot.GetComponent<Renderer>().material = slot.GetComponent<FloorButton>().correct;
            }
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        /*
        Transform child = transform.GetChild(0);
        GameObject doorObj = child.gameObject;
        doorObj.transform.position += new Vector3(0,6,0);
        */
        leftDoor.localRotation = Quaternion.Euler(0, -70, 0);
        rightDoor.localRotation= Quaternion.Euler(0, 70, 0);
        this.GetComponent<BoxCollider>().enabled = false;
    }

    public override void OnSomethingEnter(GameObject go)
    {
        //print("Abro ");
        base.OnSomethingEnter(go);
    }
    public override void OnSomethingExit(GameObject go)
    {
        //print("Cierro");
    }
}
