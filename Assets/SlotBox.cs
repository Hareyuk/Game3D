using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBox : MonoBehaviour
{
    public bool isPushed;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            isPushed = true;
        }
    }
}
