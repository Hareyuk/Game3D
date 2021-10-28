using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxPause : MessageBoxState
{
    public bool choice = false;
    public override void Init()
    {
    }

    private void Update()
    {
        if(msgBox.inputManager.pressingMouseLeftButton && !choice)
        {
            msgBox.positionLine++;
            msgBox.SetNewState(MessageBoxState.states.READLINE);
        }    
    }

    public void MakingChoice(string label_jump)
    {

    }
}
