using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntDeath : EnemyGruntState
{
    public override void Init()
    {
        enemy.anim.Play("Die");
    }
}
