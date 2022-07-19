using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtleHitted : EnemyTurtleState
{
    public float distanceHitted;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemy = GetComponent<EnemyTurtle>(); //Needed to fix a bug
    }
    public override void Init()
    {
        enemy.anim.Play("GetHit");
        //Vector3 moveDirection = rb.transform.position - Vector3.back;
        Vector3 moveDirection = rb.transform.position - enemy.character.transform.position;
        moveDirection.y = 0;
        moveDirection = moveDirection.normalized;
        rb.AddForce(moveDirection * 500f * distanceHitted);
    }

    public void returnToIdle()
    {
        enemy.SetNewState(states.IDLE);
    }
}
