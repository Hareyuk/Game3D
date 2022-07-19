using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtleIdle : EnemyTurtleState
{

    public override void Init()
    {
        enemy.anim.Play("IdleNormal");
    }

    private void Update()
    {
        OnTryAttack();
        if(enemy.detectEye)
        {
            enemy.SetNewState(states.FOLLOW);
        }
    }
}
