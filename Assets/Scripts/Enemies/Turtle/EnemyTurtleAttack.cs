using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtleAttack : EnemyTurtleState
{
    public override void Init()
    {
        enemy.anim.Play("Attack02");
    }

    public void endAnimationAttack()
    {
        enemy.SetNewState(states.IDLE);
    }
}
