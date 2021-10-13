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
        DEATH
    }
    private void Awake()
    {
        player = GetComponent<Player>();
        inputManager = GetComponent<InputManager>();
    }


    public virtual void OnTryToAttack()
    {
        if(state == PlayerState.states.IDLE || state == PlayerState.states.WALK || state == PlayerState.states.RUN)
            player.SetNewState(states.ACTION);
    }
    public virtual void Init()
    {
    }

    public virtual void Move()
    {
        float rotationSpeed = player.rotationSpeed;
        float speed = player.speed;
        Vector3 nullifyY = new Vector3(1, 0, 1);
        Vector3 forward = Vector3.Scale(cameraFollower.transform.forward, nullifyY) * (Time.deltaTime * rotationSpeed * inputManager.verticalAxis);

        Vector3 side = Vector3.Scale(cameraFollower.transform.right, nullifyY) * (Time.deltaTime * rotationSpeed * inputManager.horizontalAxis);

        transform.LookAt(transform.position + forward + side);


        //Move
        Vector3 moveVector = Vector3.forward;
        transform.Translate(moveVector * speed * Time.deltaTime);
    }
}
