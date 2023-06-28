using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruibleBox : MonoBehaviour
{
    public GameObject objectDestroyed;
    public GameObject boxToDestroy;
    bool isDestroyed = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!this.isDestroyed)
        {
            if (collision.gameObject.TryGetComponent(out UsableObjects component))
            {
                if (component.type == UsableObjects.types.WEAPON)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    GetComponent<DropItems>().DropRewards(this.transform);
                    Instantiate(objectDestroyed, this.transform);
                    Destroy(boxToDestroy);
                    this.isDestroyed=true;
                }
            }
        }
    }
}
