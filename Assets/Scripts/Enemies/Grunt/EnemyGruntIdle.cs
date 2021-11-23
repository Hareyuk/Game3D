using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntIdle : EnemyGruntState
{
    public override void Init()
    {
        enemy.anim.Play("Idle");
    }

    private void Update()
    {
        OnTryAttack();
        if(enemy.detectBackEye || enemy.detectFarEye || enemy.detectNearEye)
        {
            enemy.SetNewState(states.FOLLOW);
        }
    }
}
