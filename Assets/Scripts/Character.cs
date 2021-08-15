using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public InputManager inputManager;
    public float speed;
    public float rotationSpeed;
    //public GameObject prefabBullet;
    public GameObject referenceBox;
    public RotateWithMouse cameraFollower;
    float t = 0;
    void Update()
    {
        /*
         * float rotationValue = inputManager.horizontalAxis;
        if (rotationValue != 0)
        {
            transform.Rotate(Vector3.up * rotationValue * rotationSpeed * Time.deltaTime);
        }
        */

        if (inputManager.horizontalAxis != 0 || inputManager.verticalAxis != 0)
        {
            Vector3 moveVector = (Vector3.forward * inputManager.verticalAxis) + (Vector3.right * inputManager.horizontalAxis);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, cameraFollower.transform.localEulerAngles.y, transform.localEulerAngles.z);
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
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.transform.position = referenceBox.transform.position;
            box.transform.rotation = referenceBox.transform.rotation;
            box.tag = "Box";
            box.AddComponent<Rigidbody>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractiveObj io = other.gameObject.GetComponent<InteractiveObj>();
        if (io != null)
        {
            io.OnSomethingEnter(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractiveObj io = other.gameObject.GetComponent<InteractiveObj>();
        if (io != null)
        {
            io.OnSomethingExit(gameObject);
        }
    }
}
