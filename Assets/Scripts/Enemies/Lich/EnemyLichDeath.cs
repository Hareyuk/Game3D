using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichDeath : EnemyLichState
{
    public override void Init()
    {
        enemy.anim.Play("die");
    }
}
