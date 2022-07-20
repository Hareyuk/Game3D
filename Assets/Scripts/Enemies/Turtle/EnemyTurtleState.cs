using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtleState : MonoBehaviour
{
    public EnemyTurtle enemy;
    public enum states
    {
        IDLE,
        FOLLOW,
        ATTACK,
        HITTED
    }
    public states state;
    void Awake()
    {
        enemy = GetComponent<EnemyTurtle>();
    }
    public virtual void Init() { }

    public virtual void OnCharacterEnterViewZone(Player character)
    {
    }
    public virtual void OnCharacterExitViewZone(Player character)
    {
    }
    public virtual void Move()
    {
        Transform player = enemy.character.transform;
        float step = enemy.speedMove * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }

    public virtual void Rotate()
    {
        Transform player = enemy.character.transform;
        Vector3 targetDirection = player.position - transform.position;
        float singleStep = enemy.speedRotation * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public virtual void OnTryAttack()
    {
        if (enemy.detectAttackEye && enemy.character.lifepoints > 0)
        {
            enemy.SetNewState(states.ATTACK);
        }
    }

    public virtual void OnHitted()
    {
        enemy.SetNewState(states.HITTED);
    }
}
