using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBox : InteractiveObj
{
    public bool isPushed;
    public Door door;
    public override void OnSomethingEnter(GameObject go)
    {
        print("Algo entró");
        if(go.tag == "Box")
        {
            isPushed = true;
            door.checkSlots();
        }
        base.OnSomethingEnter(go);
    }
}
