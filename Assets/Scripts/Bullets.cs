using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed;
    float timer;
    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2) Destroy(this.gameObject);
        Vector3 moveVector = (Vector3.forward * speed * Time.deltaTime);
        this.transform.Translate(moveVector);
    }
    private void OnCollisionEnter(Collision collision)
    {
        string tagColl = collision.gameObject.tag;
        if (tagColl == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
