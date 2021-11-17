using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.anim.speed != 0)
        {
            if (!inputManager.isRunning)
            {
                player.SetNewState(PlayerState.states.WALK);
            }

            if (!CheckSpeed())
            {
                AddSpeed(2);
            }

            Move();
            OnTryToAttack();
            OnTryInteract();
        }
    }

    private bool CheckSpeed()
    {
        if (player.speed >= player.maxSpeed)
        {
            player.speed = player.maxSpeed;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void AddSpeed(float amount)
    {
        player.speed += (player.maxSpeed - player.minSpeed) * Time.deltaTime * amount;
    }
}
