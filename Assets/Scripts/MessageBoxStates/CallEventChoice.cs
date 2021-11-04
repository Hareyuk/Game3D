using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEventChoice : MonoBehaviour
{
    public string choice_label;
    public MessageBox msgBox;
    public void MakeChoice()
    {
        print("Elección hecha");
        msgBox.GetComponent<MessageBoxRead>().label_jump = choice_label;
        msgBox.SetNewState(MessageBoxState.states.READLINE);
    }
}
