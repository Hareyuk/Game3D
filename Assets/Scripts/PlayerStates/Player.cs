using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<PlayerState> allStates;
    PlayerState currentState;
    public Animator anim;
    public Character character;

    void Start()
    {
        SetNewState(PlayerState.states.IDLE);
    }

    public void SetNewState(PlayerState.states stateType) // solo puede ser llamado desde un estado:
    {
        foreach (PlayerState playerState in allStates)
        {
            if (playerState.state == stateType)
            {
                this.currentState = playerState;
                currentState.enabled = true;
                currentState.Init();
            }
            else
            {
                playerState.enabled = false;
            }
        }
    }
}
