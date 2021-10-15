using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObjects : MonoBehaviour
{
    public types type;

    public enum types
    {
        WEAPON,
        CUBE,
        KEY,
        DOOR
    }

    public void UseIt(Player player)
    {
        switch(this.type)
        {
            case types.WEAPON:
                //player.ExecuteAnimationAttack();
                break;
            case types.CUBE:
                //this.GetComponent<Pickup>().Drop(player);
                break;
            case types.KEY:
                break;
        }
    }

}
