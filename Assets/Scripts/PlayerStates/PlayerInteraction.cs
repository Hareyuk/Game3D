using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : PlayerState
{
    PlayerState previousState;
    public override void Init()
    {
        Pickup pickUpObject = player.inventory.GetPickupObject();
        if(player.ioActive != null)
        {
            player.ioActive.OnInteract(player);
            player.inventory.Refresh();
        }
        EndInteraction();
    }

    private void EndInteraction()
    {
        player.SetNewState(states.IDLE);
    }
}
