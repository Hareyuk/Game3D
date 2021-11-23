using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTargetCamera : MonoBehaviour
{
    public Transform playerCharacter;
    InteractiveEnemy enemy;
    public bool viewFar;
    public bool playerDetected = false;
    private void Awake()
    {
        enemy = GetComponentInParent<InteractiveEnemy>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == playerCharacter.name)
        {
            if (viewFar)
            {
                if (playerCharacter.GetComponent<Player>().currentState.state == PlayerState.states.RUN)
                {
                    playerDetected = true;
                }
            }
            else
            {
                playerDetected = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == playerCharacter.name)
        {
            if (viewFar)
            {
                if (playerCharacter.GetComponent<Player>().currentState.state == PlayerState.states.RUN)
                {
                    playerDetected = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider collision)
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
