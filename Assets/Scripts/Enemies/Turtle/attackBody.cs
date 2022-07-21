using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBody : MonoBehaviour
{
    EnemyTurtle enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<EnemyTurtle>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (enemy.character == other.gameObject.GetComponent<Player>())
        {
            if(enemy.character.lifepoints > 0) enemy.character.SetNewState(PlayerState.states.HITTED);
            Rigidbody rbPlayer = enemy.character.GetComponent<Rigidbody>();
            Vector3 moveDirection = rbPlayer.transform.position - enemy.transform.position;
            moveDirection.y = 0;
            moveDirection = moveDirection.normalized;
            rbPlayer.AddForce(moveDirection * 20000f);
        }
    }
}
