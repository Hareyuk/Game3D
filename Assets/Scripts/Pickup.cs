using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Transform originalParent;
    public string tagName;
    public bool weapon;
    private void Start()
    {
        originalParent = transform.parent;
    }
    public void OnGrab(Character character)
    {
        if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
        if(GetComponent<Collider>())
        {
            GetComponent<Collider>().enabled = false;
        }
        if (weapon)
        {
            transform.SetParent(character.handWeapon);
            this.transform.localEulerAngles = new Vector3 (180, 0, 0);
        }
        else
            transform.SetParent(character.hand);
        transform.localPosition = Vector3.zero;
        foreach (Transform child in transform)
        {
            child.localPosition = Vector3.zero;
            if(child.GetComponent<Rigidbody>())
            {
                Rigidbody childRb = child.GetComponent<Rigidbody>();
                childRb.useGravity = false;
            }
        }
        character.inventory.Add(GetComponent<InteractiveObj>());
        character.ioActive = null;
    }
    public void Drop(Character character)
    {
        if(GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().isKinematic = false;
        }
        if(GetComponent<Collider>())
        {
            GetComponent<Collider>().enabled = true;
        }
        transform.SetParent(originalParent);
        foreach (Transform child in transform)
        {
            Rigidbody childRb = child.GetComponent<Rigidbody>();
            childRb.useGravity = true;
        }
        character.inventory.Remove(GetComponent<InteractiveObj>());
    }
}