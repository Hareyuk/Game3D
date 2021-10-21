using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionWeapon : PlayerState
{
    public GameObject effectattack1;
    public GameObject effectattack2;

    
    public override void Init()
    {
        player.anim.Play("Attack1");
        player.canAttack = false;
        player.weapon.GetComponent<CapsuleCollider>().enabled = true;
    }

    public void AnimateEffect(float numberAttack)
    {
        switch(numberAttack)
        {
            case 1:
                print("Animation");
                GameObject fx = Instantiate(effectattack1, player.transform);
                fx.GetComponent<Animation>().Play();
                break;
        }
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
