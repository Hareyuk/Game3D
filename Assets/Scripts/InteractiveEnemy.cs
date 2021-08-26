using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveEnemy : MonoBehaviour
{
    public float lifePoints;
    public Animator anim;
    public virtual void OnSomethingEnter(GameObject go)
    {
        //print("ganó :" + score);
    }
    public virtual void OnSomethingExit(GameObject go) { }

    private void OnTriggerEnter(Collider other)
    {
        OnSomethingEnter(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        OnSomethingExit(other.gameObject);
    }

    public virtual void OnInteract(Character character)
    {
        Pickup pickup = GetComponent<Pickup>();
        if (pickup != null)
        {
            pickup.OnGrab(character);
        }
    }
}
