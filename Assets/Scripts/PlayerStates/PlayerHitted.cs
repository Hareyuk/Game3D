using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitted : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Hitted");
        player.lifepoints--;
    }

    public void CheckLifePoints()
    {
        if (player.lifepoints <= 0)
            player.SetNewState(states.DEATH);
        else
            player.SetNewState(player.lastState.state);
    }
}
