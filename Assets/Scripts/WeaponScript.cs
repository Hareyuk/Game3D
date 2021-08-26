using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision) //Se llama esta función cuando se choca con algo
    {
        GameObject go = collision.gameObject;
        string tagObject = go.tag;
        if (tagObject == "Enemy")
        {
            EnemyGrunt enemyScript = go.GetComponent<EnemyGrunt>();
            if(enemyScript.lifePoints > 0)
            {
                enemyScript.ReceiveDamage(1);
            }
        }
    }
}
