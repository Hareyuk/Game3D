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
    void Update()
    {
        float rotationValue = inputManager.horizontalAxis;
        if(rotationValue != 0)
        {
            transform.Rotate(Vector3.up * rotationValue * rotationSpeed * Time.deltaTime);
        }
        
        
        Vector3 moveVector = (Vector3.forward * inputManager.verticalAxis);
        if(moveVector != Vector3.zero)
        {
            transform.Translate(moveVector * speed * Time.deltaTime);
        }
        
        bool buttonSkill = inputManager.buttonSkill;
        if(buttonSkill)
        {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.transform.position = referenceBox.transform.position;
            box.transform.rotation = referenceBox.transform.rotation;
            box.tag = "Box";
            box.AddComponent<Rigidbody>();
        }
    }
}
