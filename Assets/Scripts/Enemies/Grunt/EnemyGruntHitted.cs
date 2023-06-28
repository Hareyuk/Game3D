using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntHitted : EnemyGruntState
{
    public override void Init()
    {
        if(enemy.lifePoints <= 0)
            enemy.SetNewState(states.DEATH);
        else
            enemy.anim.Play("Hitted");
    }
    public void CheckLifePoints()
    {
        if (enemy.lifePoints <= 0)
            enemy.SetNewState(states.DEATH);
        else
        {
            if (enemy.detectNearEye || enemy.detectFarEye || enemy.detectBackEye)
            {
                enemy.SetNewState(states.FOLLOW);
                OnTryAttack();
            }
            else
                enemy.SetNewState(states.IDLE);
        }
    }
}
