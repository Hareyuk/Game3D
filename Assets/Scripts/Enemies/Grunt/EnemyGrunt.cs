using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : InteractiveEnemy
{

    /*bool isDead = false;
    public float speed;
    public float speedRotation;
    public bool attack;
    private void Update()
    {
        if(!isDead)
        {
            playerDetected = enemyView.playerDetected;
            isPlayerNear = playerNearEnemy.playerDetected;
            anim.SetBool("isWalking", isWalking);
            Transform player = enemyView.playerCharacter;
            if (lifePoints <= 0)
            {
                isDead = true;
                anim.SetTrigger("Death");
            }

            if (isPlayerNear)
            {
                Vector3 targetDirection = player.position - transform.position;
                float singleStep = speedRotation * Time.deltaTime;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }

            if (playerDetected)
            {
                isWalking = true; 
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            }
            else
            {
                isWalking = false;
            }

            if (playerDetected && isPlayerNear)
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
        }
    }*/
}
