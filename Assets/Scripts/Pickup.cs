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
    public void OnGrab(Player player)
    {
        bool isWeapon = GetComponent<UsableObjects>().type == UsableObjects.types.WEAPON;
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
                    child.transform.SetParent(player.handWeapon);
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
            transform.SetParent(player.hand);
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
            player.inventory.Add(_sword);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            player.inventory.Add(GetComponent<InteractiveObj>());
        }
        player.ioActive = null;
        player.InteractoninUIFade();
    }
    public void Drop(Player player)
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
        player.inventory.Remove(GetComponent<InteractiveObj>());
    }
}