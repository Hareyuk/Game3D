using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCamera : MonoBehaviour
{
    public bool isCollisioning = false;
    private void OnCollisionEnter(Collision Collider)
    {
        print("Cámara haciendo colisión: " + Collider.gameObject.name);
    }
}
