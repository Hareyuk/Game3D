using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrunt : InteractiveEnemy
{

    public List<EnemyGruntState> allStates;
    public EnemyGruntState currentState;
    public EnemyGruntState lastState;
    public DetectTargetCamera goFarEye;
    public DetectTargetCamera goNearEye;
    public DetectTargetCamera goBackEye;
    public bool detectFarEye;
    public bool detectNearEye;
    public bool detectBackEye;
    public Player character;
    public float speedMove;
    public float speedRotation;
    private void Update()
    {
        detectBackEye = goBackEye.playerDetected;
        detectNearEye = goNearEye.playerDetected;
        detectBackEye = goBackEye.playerDetected;
        if (currentState.state != EnemyGruntState.states.ATTACK)
            GetComponent<EnemyGruntAttack>().DisableColliderWeapon();        
    }

    private void Start()
    {
        SetNewState(EnemyGruntState.states.IDLE);
    }
    public void SetNewState(EnemyGruntState.states stateType) // solo puede ser llamado desde un estado:
    {
        foreach (EnemyGruntState enemyState in allStates)
        {
            if (enemyState.state == stateType)
            {
                this.currentState = enemyState;
                currentState.enabled = true;
                currentState.Init();
            }
            else
            {
                enemyState.enabled = false;
            }
        }
    }
    public void OnCharacterEnterViewZone(Player character)
    {
        this.character = character;
        if (character == null)
            currentState.OnCharacterExitViewZone(character);
        else
            currentState.OnCharacterEnterViewZone(character);
    }

    public void ReceiveDamage(int amountDamage)
    {
        lifePoints -= amountDamage;
        lastState = currentState;
        if (lastState.state == EnemyGruntState.states.ATTACK)
            lastState.state = EnemyGruntState.states.FOLLOW;
        SetNewState(EnemyGruntState.states.HITTED);
    }
    /*bool isDead = false;
    public float speed;
    public float speedRotation;
    public bool attack;
    private void Update()
    {
        if(!isDead)
        {
            playerDetected = enemyView.playerDetected;
            isPlayerNear = playerNearEnemy.playerDetected;
            anim.SetBool("isWalking", isWalking);
            Transform player = enemyView.playerCharacter;
            if (lifePoints <= 0)
            {
                isDead = true;
                anim.SetTrigger("Death");
            }

            if (isPlayerNear)
            {
                Vector3 targetDirection = player.position - transform.position;
                float singleStep = speedRotation * Time.deltaTime;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }

            if (playerDetected)
            {
                isWalking = true; 
                float step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            }
            else
            {
                isWalking = false;
            }

            if (playerDetected && isPlayerNear)
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
        }
    }*/
}
