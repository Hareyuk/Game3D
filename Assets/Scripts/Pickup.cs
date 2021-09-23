using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Transform originalParent;
    public string tagName;
    private void Start()
    {
        originalParent = transform.parent;
    }
    public void OnGrab(Character character)
    {
        bool isWeapon = GetComponent<UsableObjects>().types == UsableObjects.type.WEAPON;
        InteractiveObj _sword = null;
        if (GetComponent<Rigidbody>()) 
            GetComponent<Rigidbody>().isKinematic = true;
        if(GetComponent<Collider>()) 
            GetComponent<Collider>().enabled = false;
        if (isWeapon)
        {
            foreach (Transform child in transform)
            {
                if(child.name == "Usable")
                {
                    child.gameObject.SetActive(true);
                    child.transform.SetParent(character.handWeapon);
                    child.localPosition = new Vector3(0, 0, 0);
                    child.transform.localEulerAngles = new Vector3(180, 0, 0);
                    child.GetComponent<Collider>().enabled = false;
                    _sword = child.GetComponent<InteractiveObj>();
                }
                else
                {
                    child.gameObject.SetActive(false);
                }
                
            }
            
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
        if (isWeapon)
        {
            character.inventory.Add(_sword);
        }
        else
        {
            character.inventory.Add(GetComponent<InteractiveObj>());
        }
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