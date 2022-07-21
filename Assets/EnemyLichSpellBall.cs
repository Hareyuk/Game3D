using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLichSpellBall : MonoBehaviour
{
    public Transform plane;
    public float speedRotation;
    public Transform cam;
    float rotating = 0;
    public float speedMovement;
    private void Start()
    {
        StartCoroutine(WaitDestroyGame());
    }
    void Update()
    {
        plane.LookAt(cam.position);
        plane.Rotate(0,0,rotating);
        rotating += Time.deltaTime * speedRotation;
        transform.Translate(Vector3.forward* speedMovement * Time.deltaTime);
    }

    IEnumerator WaitDestroyGame()
    {
        // wait for 1 second
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>())
        {
            Player pl = other.gameObject.GetComponent<Player>();
            if(pl.lifepoints>0) pl.SetNewState(PlayerState.states.HITTED);
        }
    }

}
