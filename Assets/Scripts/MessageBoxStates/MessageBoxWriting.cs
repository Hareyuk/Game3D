using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxWriting : MessageBoxState
{
    float timeEachLetter = 0.02f;
    float timer = 0;
    string auxText;
    List<char> listCharacters;
    public override void Init()
    {
        msgBox.textName.text = msgBox.lineFile[1].ToString();
        msgBox.textMessage.text = "";
        string textMessage = msgBox.lineFile[2];
        auxText = textMessage;
        char[] _arrayChars= textMessage.ToCharArray();
        listCharacters = new List<char>(_arrayChars);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>=timeEachLetter)
        {
            timer = 0;
            msgBox.textMessage.text += listCharacters[0];
            listCharacters.RemoveAt(0);
        }

        if(msgBox.inputManager.pressingMouseLeftButton || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            listCharacters.Clear();
            msgBox.textMessage.text = auxText;
        }


        if (listCharacters.Count == 0)
        {
            msgBox.SetNewState(MessageBoxState.states.PAUSE);
        }
    }
}
