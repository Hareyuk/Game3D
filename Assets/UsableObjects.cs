using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableObjects : MonoBehaviour
{
    public type types;

    public enum type
    {
        WEAPON,
        CUBE,
        KEY
    }

    public void UseIt(Character chara)
    {
        switch(this.types)
        {
            case type.WEAPON:
                chara.ExecuteAnimationAttack();
                break;
            case type.CUBE:
                this.GetComponent<Pickup>().Drop(chara);
                break;
            case type.KEY:
                break;
        }
    }

}
