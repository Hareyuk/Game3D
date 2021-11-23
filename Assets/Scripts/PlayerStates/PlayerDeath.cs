using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Die");
    }
}
