using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichHitted : EnemyLichState
{
    public override void Init()
    {
        enemy.anim.Play("GetHit");
    }

    public void ExecuteDeath()
    {
        enemy.SetNewState(states.DEATH);
    }
}
