using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionWeapon : PlayerState
{
    public GameObject effectattack1;
    public GameObject effectattack2;
    string currentNameAnim = "";
    public override void Init()
    {
        if (player != null)
        {
            player.anim.Play("Attack1");
            player.canAttack = false;
            currentNameAnim = player.anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        }
    }
    public void AnimateEffect(float numberAttack)
    {
        GameObject fx;
        switch(numberAttack)
        {
            case 1:
                fx = Instantiate(effectattack1, player.transform);
                fx.GetComponent<Animation>().Play();
                break;
            case 2:
                fx = Instantiate(effectattack2, player.transform);
                fx.GetComponent<Animation>().Play();
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        if(player.canAttack && inputManager.pressingMouseLeftButton && currentNameAnim != "Attack2")
        {
            currentNameAnim = "Attack2";
            player.anim.Play("Attack2");
            player.canAttack = false;
        }
    }

    public void EnablePreattack()
    {
        currentNameAnim = "Attack1";
        player.canAttack = true;
        this.enabled = true;
    }

    public void EndAttack()
    {
        currentNameAnim = "not-attack";
        this.enabled = false;
        player.SetNewState(states.IDLE);
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
