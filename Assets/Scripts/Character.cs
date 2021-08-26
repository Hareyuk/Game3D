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
    float numAnimAttack = 0;
    public WeaponScript weapon;
    IEnumerator timerAnimAttack;
    
    //Interac
    public Inventory inventory;
    public Transform hand;
    public InteractiveObj ioActive = null;

    IEnumerator ResetCooldownAttack()
    {
        attackCooldown = true;
        anim.SetFloat("numberAttack", numAnimAttack);
        weapon.GetComponent<Collider>().enabled = true;
        anim.SetTrigger("attackButton");
        StartCoroutine(ResetButtonAttack());
        yield return new WaitForSeconds(cooldownAnimAttack);
        numAnimAttack = 0;
        weapon.GetComponent<Collider>().enabled = false;
    }

    IEnumerator ResetButtonAttack()
    {
        cooldownButtonAttack = cooldownAnimAttack * 0.6f;
        print("presionó botón de ataque");
        yield return new WaitForSeconds(cooldownButtonAttack);
        attackCooldown = false;
    }

    void rotateCharacter()
    {

    }

    public void OnInteract()
    {
        Pickup pickUpObject = inventory.GetPickupObject();
        if (ioActive != null)
            ioActive.OnInteract(this);
        else if (pickUpObject != null)
            pickUpObject.Drop(this);
    }

    private void Start()
    {
        weapon.GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        bool isPressingAttack = inputManager.pressingMouseLeftButton;
        if(isPressingAttack && !attackCooldown)
        {
            timerAnimAttack = ResetCooldownAttack();
            switch (numAnimAttack)
            {
                case 0:
                    cooldownAnimAttack = 0.6f;
                    numAnimAttack = 1;
                    StopCoroutine(timerAnimAttack);
                    StartCoroutine(timerAnimAttack);
                    break;
                case 1:
                    cooldownAnimAttack = 0.8f;
                    numAnimAttack = 2;
                    StopCoroutine(timerAnimAttack);
                    StartCoroutine(timerAnimAttack);
                    break;
            }
            
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
        rotateCharacter();
        if (inputManager.horizontalAxis != 0 || inputManager.verticalAxis != 0)
        {
            float verticalAxis = inputManager.verticalAxis;
            float horizontalAxis = inputManager.horizontalAxis;
            float newRotationY = cameraFollower.transform.localEulerAngles.y;
            //Rotate to camera
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, newRotationY, transform.localEulerAngles.z);
            //Move
            Vector3 moveVector = (Vector3.forward * verticalAxis) + (Vector3.right * horizontalAxis);
            transform.Translate(moveVector * speed * Time.deltaTime);

            /* 
            transform.Translate(Vector3.forward.normalized * speed);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraFollower.transform.eulerAngles.y, transform.eulerAngles.z);
            
             * INTENTO 1
            //Transform targetPos = cameraFollower.transform;
            //Vector3 targetPostition = new Vector3(targetPos.position.x, this.transform.position.y, targetPos.position.z);
            //this.transform.LookAt(targetPostition);

            INTENTO 2
            transform.rotation = Quaternion.LookRotation(cameraFollower.transform.position, new Vector3(0,1,0));
            */
        }

        bool buttonSkill = inputManager.buttonSkill;
        if (buttonSkill)
        {
            /*GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.transform.position = referenceBox.transform.position;
            box.transform.rotation = referenceBox.transform.rotation;
            box.tag = "Box";
            box.AddComponent<Rigidbody>();*/
            OnInteract();
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
