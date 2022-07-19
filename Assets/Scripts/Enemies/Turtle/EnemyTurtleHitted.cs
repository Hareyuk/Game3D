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
    }
    public override void Init()
    {
        print("Hitted");
        enemy.anim.Play("GetHit");
        Vector3 moveDirection = rb.transform.position;
        rb.AddForce(moveDirection.normalized * -500f);
    }
}
