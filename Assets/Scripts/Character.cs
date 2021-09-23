using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public InputManager inputManager;
    public float speed;
    public float maxSpeed;
    public float minSpeed;
    public float rotationSpeed;
    //public GameObject prefabBullet;
    public GameObject referenceBox;
    public RotateWithMouse cameraFollower;
    public Animator anim;
    public bool isWalking, isRunning;
    float cooldownAnimAttack = 0;
    float cooldownButtonAttack;
    bool attackCooldown = false;
    int numAnimAttack = 0;
    public WeaponScript weapon;
    IEnumerator timerAnimAttack;

    //Interac
    public Inventory inventory;
    public Transform hand;
    public Transform handWeapon;
    public InteractiveObj ioActive = null;
    public InteractiveObj ioUsing;

    IEnumerator ResetCooldownAttack()
    {
        attackCooldown = true;
        anim.SetInteger("numberAttack", numAnimAttack);
        ioUsing.GetComponent<Collider>().enabled = true;
        anim.SetTrigger("attackButton");
        StartCoroutine(ResetButtonAttack());
        yield return new WaitForSeconds(cooldownAnimAttack);
        numAnimAttack = 0;
        ioUsing.GetComponent<Collider>().enabled = false;
    }

    IEnumerator ResetButtonAttack()
    {
        yield return new WaitForSeconds(cooldownButtonAttack);
        attackCooldown = false;
    }

    public void OnInteract()
    {
        Pickup pickUpObject = inventory.GetPickupObject();
        ioActive.OnInteract(this);
        inventory.Refresh();
        /*if (ioActive != null)
        {
        }    
        else if (pickUpObject != null)
            pickUpObject.Drop(this);*/
    }

    public void disableWeaponCollider()
    {
        if (ioUsing.GetComponent<UsableObjects>().types == UsableObjects.type.WEAPON)
        {
            ioUsing.GetComponent<Collider>().enabled = false;
        }
    }

    private void Start()
    {
        disableWeaponCollider();   
    }

    public void ExecuteAnimationAttack()
    {
        timerAnimAttack = ResetCooldownAttack();
        switch (numAnimAttack)
        {
            case 0:
                cooldownAnimAttack = 0.6f;
                cooldownButtonAttack = 0.4f;
                numAnimAttack = 1;
                StopCoroutine(timerAnimAttack);
                StartCoroutine(timerAnimAttack);
                break;
            case 1:
                cooldownAnimAttack = 0.8f;
                cooldownButtonAttack = 0.95f;
                numAnimAttack = 2;
                StopCoroutine(timerAnimAttack);
                StartCoroutine(timerAnimAttack);
                break;
        }
    }


    void Update()
    {
        bool isPressingAttack = inputManager.pressingMouseLeftButton;
        if(isPressingAttack && !attackCooldown)
        {

            ioUsing.GetComponent<UsableObjects>().UseIt(this);
            /*
            if (ioActive.GetComponent<UsableObjects>().types == UsableObjects.type.WEAPON)
            {
                ExecuteAnimationAttack();
            }*/
        }
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
        /*
         * float rotationValue = inputManager.horizontalAxis;
        if (rotationValue != 0)
        {
            transform.Rotate(Vector3.up * rotationValue * rotationSpeed * Time.deltaTime);
        }
        */

        if (inputManager.isMovingY || inputManager.isMovingX)
        {
            isWalking = true;
            if(inputManager.isRunning)
            {
                isRunning = true;
                if(speed < maxSpeed)
                {
                    speed += (maxSpeed - minSpeed) * Time.deltaTime * 2;
                }
            }
            else
            {
                isRunning = false;
                if(speed > minSpeed)
                {
                    speed -= (maxSpeed - minSpeed) * Time.deltaTime * 2;
                }
            }
        }
        else
        {
            isWalking = false;
        }
        if (isWalking)
        {
            this.Move();
        }

        bool buttonSkill = inputManager.buttonSkill;
        if (buttonSkill)
        {
            OnInteract();
        }
    }

    private void Move()
    {
        Vector3 nullifyY = new Vector3(1, 0, 1);
        Vector3 forward = Vector3.Scale(cameraFollower.transform.forward, nullifyY) * (Time.deltaTime * rotationSpeed * inputManager.verticalAxis);

        Vector3 side = Vector3.Scale(cameraFollower.transform.right, nullifyY) * (Time.deltaTime * rotationSpeed * inputManager.horizontalAxis);

        transform.LookAt(transform.position + forward + side);

        /*
        float verticalAxis = inputManager.verticalAxis;
        float horizontalAxis = inputManager.horizontalAxis;
        float cam_y = cameraFollower.transform.localEulerAngles.y;
        float new_rot_y = 0;
        if (verticalAxis > 0 && horizontalAxis == 0)
        {
            new_rot_y = cam_y * verticalAxis;
        }
        else if (verticalAxis > 0 && horizontalAxis != 0)
        {
            new_rot_y = cam_y + 45 * horizontalAxis;
        }
        if (verticalAxis < 0 && horizontalAxis == 0)
        {
            new_rot_y = cam_y + 180 * verticalAxis;
        }
        else if (verticalAxis < 0 && horizontalAxis != 0)
        {
            new_rot_y = cam_y + 180 *verticalAxis + 45 * -horizontalAxis;
        }
        if (verticalAxis == 0 && horizontalAxis != 0)
        {
            new_rot_y = cam_y + 90 * horizontalAxis;
        }  */
        /*
        if (verticalAxis > 0 && horizontalAxis == 0)
        {
            new_rot_y = cam_y;
        }
        else if (verticalAxis > 0 && horizontalAxis > 0)
        {
            new_rot_y = cam_y + 45;
        }
        else if(verticalAxis > 0 && horizontalAxis < 0)
        {
            new_rot_y = cam_y - 45;
        }

        if (verticalAxis < 0 && horizontalAxis == 0)
        {
            new_rot_y = cam_y + 180;
        }
        else if (verticalAxis < 0 && horizontalAxis > 0)
        {
            new_rot_y = cam_y + 135;
        }
        else if (verticalAxis < 0 && horizontalAxis < 0)
        {
            new_rot_y = cam_y + 225;
        }

        if (verticalAxis == 0 && horizontalAxis > 0)
        {
            new_rot_y = cam_y + 90;
        }
        else if (verticalAxis == 0 && horizontalAxis < 0)
        {
            new_rot_y = cam_y - 90;
        }*/
        //rotateObject.localEulerAngles = new Vector3(0, new_rot_y, 0);
        /*
        rotateObject.localRotation = Quaternion.Euler(0f, new_rot_y,0);
        Vector3 targetDirection = rotationReference.position - transform.position;
        targetDirection.y = 0;
        float singleStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        var targetRotation = Quaternion.LookRotation(newDirection);
        transform.rotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * rotationSpeed);
        */
        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, new_rot_y, 0), Time.deltaTime * rotationSpeed);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, new_rot_y, transform.localEulerAngles.z);

        //Move
        Vector3 moveVector = Vector3.forward;
        transform.Translate(moveVector * speed * Time.deltaTime);
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
