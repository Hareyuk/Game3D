using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionKey : PlayerState
{
    Animation animKey;
    public override void Init()
    {
        player.anim.Play("InteractionKey");
        Transform key = player.ioUsing.transform;
        animKey  = key.GetChild(0).GetComponent<Animation>();
        animKey.Play("KeyOpen");
    }

    public void EndAction()
    {
        animKey.Play("RotatingKey");
        player.SetNewState(player.lastState.state);
    }
}
