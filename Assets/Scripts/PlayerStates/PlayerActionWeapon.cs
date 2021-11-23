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
    }

    public void AnimateEffect(float numberAttack)
    {
        switch(numberAttack)
        {
            case 1:
                GameObject fx = Instantiate(effectattack1, player.transform);
                fx.GetComponent<Animation>().Play();
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if(player.canAttack && inputManager.pressingMouseLeftButton)
        {
            print("Ataque 2 Go!");
            player.anim.Play("Attack2");
            player.canAttack = false;
        }

        if(player.anim.name != "Attack1" && player.anim.name != "Attack2")
        {
            EndAttack();
        }
    }

    public void EnablePreattack()
    {
        player.canAttack = true;
    }

    public void EndAttack()
    {
        player.SetNewState(player.lastState.state);
    }

    public void EnableColliderWeapon()
    {
        player.weapon.GetComponentInChildren<Collider>().enabled = true;

    }

    public void DisableColliderWeapon()
    {
        player.weapon.GetComponentInChildren<Collider>().enabled = false;
    }

}
