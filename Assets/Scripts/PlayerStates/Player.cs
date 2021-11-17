using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            InteractionUIShow(io);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractiveObj io = other.gameObject.GetComponent<InteractiveObj>();
        if (io != null)
        {
            io.OnSomethingExit(gameObject);
            InteractoninUIFade();
            ioActive = null;
        }
    }


    //UI
    public Image UIButtonInteraction;
    public Text txtButtonInteraction;
    void InteractionUIShow(InteractiveObj io)
    {
        UIButtonInteraction.gameObject.SetActive(true);
        txtButtonInteraction.text = io.tipText;
        //Animator anim = UIButtonInteraction.GetComponent<Animator>();
        //anim.SetBool("Show", true);
        /*
        //Openable Doors
        try
        {
            OpenableDoor door = io.GetComponent<OpenableDoor>();
            Text txt = UIButtonInteraction.transform.GetChild(0).GetChild(1).GetComponent<Text>();
            txt.text = "Abrir puerta";
            UIInteractiveSlot.gameObject.SetActive(true);
        }
        catch
        {
            
        }

        //Usables
        try
        {
            UsableObjects uo = io.GetComponent<UsableObjects>();
            Text txt = UIButtonInteraction.transform.GetChild(0).GetChild(1).GetComponent<Text>();
            switch(uo.type)
            {
                case UsableObjects.types.KEY:
                    txt.text = "Agarrar llave";
                    break;

                case UsableObjects.types.WEAPON:
                    txt.text = "Agarrar arma";
                    break;

                case UsableObjects.types.CUBE:
                    txt.text = "Agarrar objeto";
                    break;

            }
            UIInteractiveSlot.gameObject.SetActive(true);
        }
        catch
        {

        }
        */
    }

    void InteractoninUIFade()
    {
        //Animator anim = UIButtonInteraction.GetComponent<Animator>();
        //anim.Play("UIInteractionFade");
        UIButtonInteraction.gameObject.SetActive(false);
    }
}
