using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public List<MessageBoxState> allStates;
    public MessageBoxState currentState;
    public GameObject BoxChoice;
    public InputManager inputManager;
    public Text textName;
    public Text textMessage;
    public List<string> arrayFileText;
    public int positionLine = 0;
    public string[] lineFile;
    public Transform msgImage;
    public TextAsset currentFile;
    public List<Animator> animCharacters;
    void Start()
    {
        SetNewState(MessageBoxState.states.OUT);
    }
    public void SetNewState(MessageBoxState.states stateType) // solo puede ser llamado desde un estado:
    {
        foreach (MessageBoxState messageState in allStates)
        {
            if (messageState.state == stateType)
            {
                this.currentState = messageState;
                currentState.enabled = true;
                currentState.Init();
            }
            else
            {
                messageState.enabled = false;
            }
        }
    }

    public void ExecuteEventMessage(TextAsset file, List<Animator> list)
    {
        currentFile = file;
        animCharacters = list;
        SetNewState(MessageBoxState.states.SHOW);
    }

    public void ReanudeAnimationCharacters()
    {
        foreach(Animator anim in animCharacters)
        {
            anim.speed = 1;
        }
    }
}
