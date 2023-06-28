using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLich : InteractiveEnemy
{
    public List<EnemyLichState> allStates;
    public EnemyLichState currentState;
    public DetectTargetCamera goAttackEye;
    public bool detectAttackEye;
    public Player character;
    public float speedRotation;
    void Start()
    {
        anim = GetComponent<Animator>();
        SetNewState(EnemyLichState.states.IDLE);
    }

    private void Update()
    {
        detectAttackEye = goAttackEye.playerDetected;
    }
    public void SetNewState(EnemyLichState.states stateType) // solo puede ser llamado desde un estado:
    {
        foreach (EnemyLichState enemyState in allStates)
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

    public override void ReceiveDamage(float amountDamage)
    {
        //if(currentState.state != EnemyLichState.states.DEATH) SetNewState(EnemyLichState.states.HITTED);
        if (currentState.state != EnemyLichState.states.DEATH) SetNewState(EnemyLichState.states.DEATH);
    }
}
