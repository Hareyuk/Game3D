using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : PlayerState
{
    public override void Init()
    {
        print("probando walking");
        player.anim.Play("Walking");
    }

    private void Update()
    {
        if(inputManager.horizontalAxis==0 && inputManager.verticalAxis==0)
        {
            player.SetNewState(PlayerState.states.IDLE);
        }

        if(inputManager.isRunning)
        {
            player.SetNewState(PlayerState.states.RUN);
        }
    }
}
