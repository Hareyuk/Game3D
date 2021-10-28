using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxState : MonoBehaviour
{
    public enum states
    {
        SHOW,
        FADE,
        READLINE,
        WRITING,
        PAUSE,
        OUT
    }

    private void Awake()
    {
        msgBox = GetComponent<MessageBox>();
    }

    public MessageBox msgBox;
    public states state;

    public virtual void Init()
    {
    }

}
