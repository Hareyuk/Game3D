using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : InteractiveEnemy
{
    bool isDead = false;
    private void Update()
    {
        if (lifePoints <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("Death");
        }

        if(playerDetected)
        {
            isWalking = true;
            anim.SetBool("isWalking", anim);
        }
    }
}
