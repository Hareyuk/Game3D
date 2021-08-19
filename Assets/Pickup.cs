using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Transform originalParent;
    private void Start()
    {
        originalParent = transform.parent;
    }
    public void OnGrab(Character character)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        transform.SetParent(character.hand);
        transform.localPosition = Vector3.zero;
        foreach (Transform child in transform)
        {
            child.localPosition = Vector3.zero;
            Rigidbody childRb = child.GetComponent<Rigidbody>();
            childRb.useGravity = false;
        }
        character.inventory.Add(GetComponent<InteractiveObj>());
        character.ioActive = null;
    }
    public void Drop(Character character)
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Collider>().enabled = true;
        transform.SetParent(originalParent);
        foreach (Transform child in transform)
        {
            Rigidbody childRb = child.GetComponent<Rigidbody>();
            childRb.useGravity = true;
        }
        character.inventory.Remove(GetComponent<InteractiveObj>());
    }
}