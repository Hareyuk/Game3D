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
        if(!inputManager.isRunning)
        {
            player.SetNewState(PlayerState.states.WALK);
        }
    }
}
