using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxRead : MessageBoxState
{

    string label_jump = "";
    public override void Init()
    {
        ReadLine();
    }

    void ReadLine()
    {
        int pos = msgBox.positionLine;
        string line = msgBox.arrayFileText[pos];
        string[] _lines=line.Split(char.Parse("|"));
        switch (_lines[0])
        {
            case "line":
                msgBox.lineFile = _lines;
                msgBox.SetNewState(MessageBoxState.states.WRITING);
                break;
            case "choices":
                pos++;
                pos = CreateChoices(pos);
                msgBox.positionLine = pos + 1; //next to "end-choices"
                msgBox.SetNewState(MessageBoxState.states.PAUSE);
                break;
            case "label-read":
                break;
            case "label-jump":
                break;
            case "end-text":
                break;
        }
    }

    int CreateChoices(int pos)
    {
        Transform parent = transform.GetChild(1);
        while (msgBox.arrayFileText[pos] != "end-choices")
        {
            GameObject newChoice = msgBox.BoxChoice;
            GameObject textChoice = newChoice.transform.GetChild(0).gameObject;
            textChoice.GetComponent<UnityEngine.UI.Text>().text = msgBox.arrayFileText[pos];
            newChoice.SetActive(true);
            Instantiate(newChoice, parent);
            pos++;
        }
        return pos;
    }

}
