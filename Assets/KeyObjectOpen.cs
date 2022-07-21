using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObjectOpen : MonoBehaviour
{
    OpenWithKey collisionDoor;
    public Inventory inventoryCharacter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<OpenWithKey>())
        {
            collisionDoor = other.gameObject.GetComponent<OpenWithKey>();
        }
    }

    public void DoorOpen()
    {
        if(collisionDoor)
        {
            collisionDoor.OpenDoor();
            /*inventoryCharacter.Remove(this.GetComponentInParent<InteractiveObj>());
            Destroy(transform.parent.gameObject);*/
        }
    }
}
