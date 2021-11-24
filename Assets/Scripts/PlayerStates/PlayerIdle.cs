using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Idle_Battle");
    }

    private void Update()
    {
        OnTryToAction();
        OnTryInteract();
        if (inputManager.horizontalAxis != 0 || inputManager.verticalAxis != 0)
        {
            player.SetNewState(PlayerState.states.WALK);
        }

    }

}
