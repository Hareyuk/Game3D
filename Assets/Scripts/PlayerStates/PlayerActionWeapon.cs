using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionWeapon : PlayerState
{
    public override void Init()
    {
        player.anim.Play("Attack1");
        player.canAttack = false;
        player.weapon.GetComponent<CapsuleCollider>().enabled = true;
    }

    private void Update()
    {
        if(player.canAttack && inputManager.pressingMouseLeftButton)
        {
            player.anim.Play("Attack2");
            player.canAttack = false;
        }
    }

    public void EnablePreattack()
    {
        player.canAttack = true;
    }

    public void EndAttack()
    {
        player.SetNewState(PlayerState.states.IDLE);
        player.weapon.GetComponent<CapsuleCollider>().enabled = false;
    }

}
