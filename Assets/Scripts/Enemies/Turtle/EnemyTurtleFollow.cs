using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtleFollow : EnemyTurtleState
{
    public override void Init()
    {
        enemy.anim.Play("WalkFWD");
    }

    private void Update()
    {
        OnTryAttack();
        Rotate(); 
        Move();
        if (enemy.detectAttackEye) enemy.SetNewState(states.ATTACK);
    }
}
