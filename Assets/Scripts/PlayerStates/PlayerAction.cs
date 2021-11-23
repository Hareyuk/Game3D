﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : PlayerState
{
    public override void Init()
    {
        UsableObjects.types typeIoActive = player.ioUsing.GetComponent<UsableObjects>().type;
        if (typeIoActive == UsableObjects.types.WEAPON)
        {
            player.SetNewState(PlayerState.states.ACTIONATTACK);
        }
        else if (typeIoActive == UsableObjects.types.KEY)
        {
            player.SetNewState(PlayerState.states.ACTIONKEY);
        }
        else if (typeIoActive == UsableObjects.types.CUBE)
        {
            print("Objeto cubo");
            player.SetNewState(PlayerState.states.ACTIONOTHER);
        }
    }

    private void FixedUpdate()
    {
        if(player.currentState.state == states.ACTION)
        {
            player.SetNewState(states.IDLE);
        }
    }
}
