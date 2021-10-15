using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<PlayerState> allStates;
    public PlayerState currentState;
    public Animator anim;
    public Character character;

    //Movement Speed
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float rotationSpeed;

    //Camera
    public RotateWithMouse cameraFollower;

    //Action Weapon
    public float cooldownAnimAttack = 0;
    public float cooldownButtonAttack;
    public bool canAttack = false;
    public int numAnimAttack = 0;
    public WeaponScript weapon;
    public IEnumerator timerAnimAttack;

    //Inventory
    public Inventory inventory;

    //Interac
    public Transform hand;
    public Transform handWeapon;
    public InteractiveObj ioActive = null;
    public InteractiveObj ioUsing;

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

    private void OnTriggerEnter(Collider other)
    {
        InteractiveObj io = other.gameObject.GetComponent<InteractiveObj>();
        if (io != null)
        {
            io.OnSomethingEnter(gameObject);
            ioActive = io;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractiveObj io = other.gameObject.GetComponent<InteractiveObj>();
        if (io != null)
        {
            io.OnSomethingExit(gameObject);
            ioActive = null;
        }
    }
}
