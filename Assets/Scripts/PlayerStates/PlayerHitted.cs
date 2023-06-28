using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitted : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Hitted");
        player.lifepoints -= 1*player.multiplierDmg;
    }
    public void CheckLifePointsPlayer(int state) //UPDATE 0 = check death | 1 = go to idle
    {
        if(state == 0)
        {
            if (player.lifepoints <= 0)
                player.SetNewState(states.DEATH);
        }
        else
        {
            if (player.lifepoints <= 0)
                player.SetNewState(states.DEATH);
            else
                player.SetNewState(states.IDLE);
        }
    }
}
