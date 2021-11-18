using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    public List<GameObject> rewardsDrop;
    public void DropRewards(Transform parent)
    {
        foreach(GameObject go in rewardsDrop)
        {
            Instantiate(go, parent);
        }
    }
}
