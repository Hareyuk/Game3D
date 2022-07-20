using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichAttack : EnemyLichState
{
    public override void Init()
    {
        enemy.anim.Play("attack01");
    }
    private void Update()
    {
        if (!enemy.detectAttackEye) enemy.SetNewState(states.IDLE);
        else Rotate();
    }

    public void CastSpell()
    {
        enemy.anim.speed = 0.5f;
    }

    public void RestoreAnimationSpeed()
    {
        enemy.anim.speed = 1;
    }
}
