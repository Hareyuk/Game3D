using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenableDoor : InteractiveObj
{
    public Transform leftDoor;
    public Transform rightDoor;
    bool openable = true;
    public void OpenDoor()
    {
        if(openable)
        {
            leftDoor.eulerAngles = new Vector3(0, -70, 0);
            rightDoor.eulerAngles = new Vector3(0, 70, 0);
        }
    }
    public override void OnSomethingEnter(GameObject go)
    {
        base.OnSomethingEnter(go);
    }
    public override void OnSomethingExit(GameObject go)
    {
        if(go.transform.localPosition.z < -5.1)
        {
            openable = false;
            leftDoor.eulerAngles = new Vector3(0, 0, 0);
            rightDoor.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
