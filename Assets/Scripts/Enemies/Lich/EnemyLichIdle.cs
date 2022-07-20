using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichIdle : EnemyLichState
{
    public override void Init()
    {
        enemy.anim.Play("Idle");
    }

    private void Update()
    {
        if(enemy.detectAttackEye)
        {
            enemy.SetNewState(states.ATTACK);
        }
    }
}
