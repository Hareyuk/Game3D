using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichIdle : EnemyLichState
{
    public override void Init()
    {
        enemy.anim.Play("Idle");
        enemy.anim.speed = 1;
    }

    private void Update()
    {
        if(enemy.detectAttackEye && enemy.character.lifepoints>0)
        {
            enemy.SetNewState(states.ATTACK);
        }
    }
}
