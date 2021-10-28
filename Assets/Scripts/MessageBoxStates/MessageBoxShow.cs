using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;


public class MessageBoxShow : MessageBoxState
{
    
    public float speed;
    public override void Init()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        msgBox.textName.text = "";
        msgBox.textMessage.text = "";
        ReadFileData();
    }

    void ReadFileData()
    {
        msgBox.arrayFileText.Clear();
        string textFile = msgBox.currentFile.text;
        string[] _lines = Regex.Split(textFile, "\n|\r|\r\n");
        for (int i = 0; i < _lines.Length; i++)
        {
            string valueLine = _lines[i];
            if(valueLine != "")
            {
                msgBox.arrayFileText.Add(valueLine);
            }
        }

    }

    private void Update()
    {
        if (msgBox.msgImage.localPosition.y < -302)
        {
            Vector3 moveImg = msgBox.msgImage.up * speed;
            msgBox.msgImage.Translate(Time.deltaTime * moveImg);
        }
        else
        {
            msgBox.msgImage.localPosition = new Vector3(0,-302,0);
            msgBox.SetNewState(MessageBoxState.states.READLINE);
        }
    }
}
