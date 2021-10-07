using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : PlayerState
{
    PlayerState previousState;
    public override void Init()
    {
        print("probando walking");
        player.anim.Play("Walking");
    }

    
}
