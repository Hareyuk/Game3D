using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTargetCamera : MonoBehaviour
{
    public bool playerDetected;
    public Transform playerCharacter;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == playerCharacter.name)
        {
            playerDetected = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == playerCharacter.name)
        {
            playerDetected = false;
        }
    }
}

/*
 * 
 * public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
 * if (Vector3.Distance(transform.position, playerCharacter.position) <= MaxDist)//not MinDist
        {
            //if (Vector3.Distance(transform.position, playerCharacter.position) <= MinDist)//not MaxDist
            //{
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            //}
        }
*/
