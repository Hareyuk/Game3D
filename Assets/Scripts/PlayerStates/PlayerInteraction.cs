using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : PlayerState
{
    PlayerState previousState;
    public override void Init()
    {
        print("probando Interacción");
        player.anim.Play("Interaction");
        Pickup pickUpObject = player.inventory.GetPickupObject();
        player.ioActive.OnInteract(player);
        player.inventory.Refresh();
        EndInteraction();
    }

    private void EndInteraction()
    {
        player.SetNewState(lastState);
    }
}
