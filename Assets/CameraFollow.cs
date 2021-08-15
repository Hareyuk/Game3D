using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Character target;
    public float distance, height;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posTarget = target.transform.position;
        transform.position = new Vector3(posTarget.x, posTarget.y + height, posTarget.z - distance);
    }
}
