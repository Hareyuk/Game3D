using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCamera : MonoBehaviour
{
    public bool isCollisioning = false;
    private void OnCollisionEnter(Collision Collider)
    {
        print("C�mara haciendo colisi�n: " + Collider.gameObject.name);
    }
}
