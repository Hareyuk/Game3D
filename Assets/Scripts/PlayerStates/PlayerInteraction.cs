using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : PlayerState
{
    PlayerState previousState;
    public override void Init()
    {
        print("probando Interacción");
        Pickup pickUpObject = player.inventory.GetPickupObject();
        player.ioActive.OnInteract(player);
        player.inventory.Refresh();
        EndInteraction();
    }

    private void EndInteraction()
    {
        player.SetNewState(player.lastState.state);
    }
}
