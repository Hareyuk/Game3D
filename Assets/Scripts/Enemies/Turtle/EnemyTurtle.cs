using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurtle : InteractiveEnemy
{
    public List<EnemyTurtleState> allStates;
    public EnemyTurtleState currentState;
    public DetectTargetCamera goEye;
    public bool detectEye;
    public DetectTargetCamera goAttackEye;
    public bool detectAttackEye;
    public Player character;
    public float speedMove;
    public float speedRotation;

    void Start()
    {
        SetNewState(EnemyTurtleState.states.IDLE);
    }

    private void Update()
    {
        detectEye = goEye.playerDetected;
        detectAttackEye = goAttackEye.playerDetected;
    }
    public void SetNewState(EnemyTurtleState.states stateType) // solo puede ser llamado desde un estado:
    {
        foreach (EnemyTurtleState enemyState in allStates)
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
        //No se puede matarlo
        SetNewState(EnemyTurtleState.states.HITTED);
    }
}
