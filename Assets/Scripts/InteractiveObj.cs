using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObj : MonoBehaviour
{
    public string tipText = "Te olvidaste de escribir este texto";
    //public int score;
    //Las funciones virtual son funciones que pueden ser extendidas, sobrescritas por otra clase y etc
    public virtual void OnSomethingEnter(GameObject go) {
        //print("ganó :" + score);
    }
    public virtual void OnSomethingExit(GameObject go) {}

    private void OnTriggerEnter(Collider other)
    {
        OnSomethingEnter(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        OnSomethingExit(other.gameObject);
    }

    public virtual void OnInteract(Player player)
    {
        Pickup pickup = GetComponent<Pickup>();
        if (pickup != null)
        {
            pickup.OnGrab(player);
        }
        else
        {
            if(this.TryGetComponent(out OpenableDoor component))
            {
                component.OpenDoor();
            }
        }
    }
}
