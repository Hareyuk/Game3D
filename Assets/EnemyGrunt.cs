using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : InteractiveEnemy
{
    // Update is called once per frame
    void Update()
    {          
    }

    public void ReceiveDamage(float amount)
    {
        lifePoints -= amount;
        if(lifePoints <= 0)
        {
            LifePointsZero();
        }
    }

    void LifePointsZero()
    {
        anim.SetTrigger("Death");
    }
}
