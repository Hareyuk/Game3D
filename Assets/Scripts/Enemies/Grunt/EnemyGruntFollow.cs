using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntFollow : EnemyGruntState
{
    public override void Init()
    {
        enemy.anim.Play("Walk");
    }
    private void Update()
    {

        OnTryAttack();
        if (!enemy.detectFarEye && !enemy.detectBackEye && !enemy.detectNearEye)
        {
            enemy.SetNewState(states.IDLE);

        }
        if (enemy.detectBackEye)
        {
            Rotate();
        }

        if (enemy.detectNearEye)
        {
            enemy.speedMove = 8;
            Move();
        }

        if (enemy.detectFarEye)
        {
            enemy.speedMove = 11;
            Move();
        }
    }
}
