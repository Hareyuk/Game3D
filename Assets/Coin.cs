using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : InteractiveObj
{
    public override void OnSomethingEnter(GameObject go)
    {
        print("agarre");
        base.OnSomethingEnter(go);
    }
}
