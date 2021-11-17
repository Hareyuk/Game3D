using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Walking");
    }

    private void Update()
    {
        if(player.anim.speed != 0)
        {
            if (inputManager.horizontalAxis == 0 && inputManager.verticalAxis == 0)
            {
                player.SetNewState(PlayerState.states.IDLE);
            }

            if (inputManager.isRunning)
            {
                player.SetNewState(PlayerState.states.RUN);
            }

            if (!CheckSpeed())
            {
                ReduceSpeed(2);
            }

            Move();
            OnTryToAttack();
            OnTryInteract();
        }
        
    }

    private void ReduceSpeed(float amount)
    {
        player.speed -= (player.maxSpeed - player.minSpeed) * Time.deltaTime * amount;
    }

    private bool CheckSpeed()
    {
        if(player.speed <= player.minSpeed)
        {
            player.speed = player.minSpeed;
            return true;
        }
        else
        {
            return false;
        }
    }
}
