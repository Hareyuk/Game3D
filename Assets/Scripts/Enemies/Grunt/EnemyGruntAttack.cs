using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGruntAttack : EnemyGruntState
{
    public GameObject weapon;
    public override void Init()
    {
        enemy.anim.Play("Attack");
    }


    public void ColliderWeapon()
    {
        weapon.GetComponent<Collider>().enabled = true;
    }

    public void DisableColliderWeapon()
    {
        weapon.GetComponent<Collider>().enabled = false;
    }

    public void BackToIdle()
    {
        enemy.SetNewState(states.IDLE);
    }
}
