using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWithKey : MonoBehaviour
{

    public Transform leftDoor;
    public Transform rightDoor;
    public void OpenDoor()
    {
        leftDoor.localRotation = Quaternion.Euler(0, -70, 0);
        rightDoor.localRotation = Quaternion.Euler(0, 70, 0);
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
