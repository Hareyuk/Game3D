using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveEnemy : MonoBehaviour
{
    public float lifePoints;
    public Animator anim;
    /*public DetectTargetCamera enemyView;
    public DetectTargetCamera enemyViewFar;
    public DetectTargetCamera playerNearEnemy;
    public bool isWalking;
    public bool playerDetected;
    public bool isPlayerNear;
    */
    public virtual void OnSomethingEnter(GameObject go)
    {

    }
    public virtual void ReceiveDamage(float amount)
    {
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

    public virtual void OnInteract(Player character)
    {
        
    }
}
