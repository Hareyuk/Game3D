using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObj
{
    public List<SlotBox> listSlots;
    public void checkSlots()
    {
        bool SlotsPushed = true;
        foreach (SlotBox slot in listSlots)
        {
            if(slot.isPushed != true)
            {
                SlotsPushed = false;
            }
        }
        if(SlotsPushed)
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        Transform child = transform.GetChild(0);
        GameObject doorObj = child.gameObject;
        doorObj.transform.position += new Vector3(0,6,0);
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
