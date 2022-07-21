using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichAttack : EnemyLichState
{
    public Transform characterHead;
    public GameObject prefabSpell;
    public Transform referenceSpell;
    public Transform parentSpell;
    public override void Init()
    {
        enemy.anim.Play("attack01");
    }
    private void Update()
    {
        if (enemy.detectAttackEye && enemy.character.lifepoints > 0)
        {
            Rotate();
        }
        else
        {
            enemy.anim.speed = 0;
            enemy.SetNewState(states.IDLE);
        }
    }

    public void CastSpell()
    {
        GameObject prefab = Instantiate(prefabSpell, parentSpell);
        prefab.transform.position = referenceSpell.position;
        prefab.transform.LookAt(characterHead.position);
        prefab.SetActive(true);
        enemy.anim.speed = 0.65f;
    }

    public void RestoreAnimationSpeed()
    {
        enemy.anim.speed = 1;
    }
}
