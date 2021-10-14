using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Player player;
    public states state;
    public InputManager inputManager;
    public states lastState;
    public RotateWithMouse cameraFollower;
    public enum states
    {
        IDLE,
        ACTION,
        INTERACTION,
        WALK,
        RUN,
        HITTED,
        DEATH,
        ACTIONATTACK,
        ACTIONKEY,
        ACTIONOTHER
    }
    private void Awake()
    {
        player = GetComponent<Player>();
        inputManager = GetComponent<InputManager>();
        cameraFollower = player.cameraFollower;
    }


    public virtual void OnTryToAttack()
    {
        if(inputManager.pressingMouseLeftButton)
        {
            player.SetNewState(states.ACTION);
        }
    }

    public virtual void OnTryInteract()
    {
        if(inputManager.buttonSkill)
        {
            lastState = player.currentState.state;
            player.SetNewState(states.INTERACTION);
        }    
    }
    public virtual void Init()
    {
    }

    public virtual void Move()
    {
        Vector3 nullifyY = new Vector3(1, 0, 1);
        Vector3 forward = Vector3.Scale(cameraFollower.transform.forward, nullifyY) * (Time.deltaTime * player.rotationSpeed * inputManager.verticalAxis);

        Vector3 side = Vector3.Scale(cameraFollower.transform.right, nullifyY) * (Time.deltaTime * player.rotationSpeed * inputManager.horizontalAxis);

        transform.LookAt(transform.position + forward + side);


        //Move
        Vector3 moveVector = Vector3.forward;
        transform.Translate(moveVector * player.speed * Time.deltaTime);
    }
}
