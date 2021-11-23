using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntHitted : EnemyGruntState
{
    public override void Init()
    {
        enemy.anim.Play("Hitted");
    }
    public void CheckLifePoints()
    {
        if (enemy.lifePoints <= 0)
            enemy.SetNewState(states.DEATH);
        else
            enemy.SetNewState(enemy.lastState.state);
    }
}
