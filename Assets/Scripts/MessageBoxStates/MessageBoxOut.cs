using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxOut : MessageBoxState
{
    public override void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}
