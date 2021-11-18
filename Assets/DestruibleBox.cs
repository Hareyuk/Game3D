using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruibleBox : MonoBehaviour
{
    public List<GameObject> rewardsDrop;
    public GameObject objectDestroyed;
    public GameObject boxToDestroy;
    bool isDestroyed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isDestroyed)
        {
            print("Triggered: " + other.name);
            if (other.GetComponent<UsableObjects>().type == UsableObjects.types.WEAPON)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                Instantiate(objectDestroyed, this.transform);
                Destroy(boxToDestroy);
            }
        }
    }
}
