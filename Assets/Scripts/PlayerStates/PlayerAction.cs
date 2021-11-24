using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : PlayerState
{
    public override void Init()
    {
    }

    private void OnEnable()
    {
        UsableObjects.types typeIoActive = player.ioUsing.GetComponent<UsableObjects>().type;
        if (typeIoActive == UsableObjects.types.WEAPON)
        {
            player.SetNewState(states.ACTIONATTACK);
        }
        else if (typeIoActive == UsableObjects.types.KEY)
        {
            player.SetNewState(states.ACTIONKEY);
        }
        else if (typeIoActive == UsableObjects.types.CUBE)
        {
            print("Objeto cubo");
            player.SetNewState(states.ACTIONOTHER);
        }
    }
}
