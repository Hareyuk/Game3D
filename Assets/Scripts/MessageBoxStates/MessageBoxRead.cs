using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MessageBoxRead : MessageBoxState
{

    public string label_jump = "";
    bool should_go = false;
    public override void Init()
    {
        ReadLine();
    }

    private void Update()
    {
        if(should_go)
        {
            msgBox.SetNewState(MessageBoxState.states.FADE);
        }
    }

    void ReadLine()
    {
        //Destroy all choices Buttons
        if(label_jump != "")
        {
            Transform ChoicesList = transform.GetChild(1).transform;
            foreach(Transform child in ChoicesList)
            {
                Destroy(child.gameObject);
            }
            msgBox.GetComponent<MessageBoxPause>().choice = false;
        }
        int pos = msgBox.positionLine;
        string lineRead = msgBox.arrayFileText[pos];
        string[] lineSplitted=lineRead.Split(char.Parse("|"));
        print("Pos: " + pos + " - Linea leída: " + lineRead);
        switch (lineSplitted[0])
        {
            case "line":
                msgBox.lineFile = lineSplitted;
                msgBox.SetNewState(MessageBoxState.states.WRITING);
                break;
            case "choices":
                pos++;
                pos = CreateChoices(pos);
                msgBox.positionLine = pos + 1; //next to "end-choices"
                GetComponent<MessageBoxPause>().choice = true;
                msgBox.SetNewState(MessageBoxState.states.PAUSE);
                break;
            case "label-read":
                while(label_jump != lineSplitted[1])
                {
                    pos++;
                    lineRead = msgBox.arrayFileText[pos];
                    lineSplitted = lineRead.Split(char.Parse("|"));
                }
                pos++;
                /*if(label_jump == lineSplitted[1])
                {
                    pos++;
                }
                else
                {
                    do
                    {
                        pos++;
                        lineRead = msgBox.arrayFileText[pos];
                        lineSplitted = lineRead.Split(char.Parse("|"));
                    } while (label_jump != lineSplitted[1]);
                }*/
                msgBox.positionLine = pos;
                label_jump = "";
                ReadLine();
                break;
            case "label-jump":
                label_jump = lineSplitted[1];
                do
                {
                    pos++;
                    lineRead = msgBox.arrayFileText[pos];
                    lineSplitted = lineRead.Split(char.Parse("|"));
                } while (lineSplitted[0] != "label-read");
                msgBox.positionLine = pos;
                ReadLine();
                break;

            case "end-text":
                should_go = true;
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
            string lineRead = msgBox.arrayFileText[pos];
            string[] lineSplitted= lineRead.Split(char.Parse("|"));
            textChoice.GetComponent<UnityEngine.UI.Text>().text = lineSplitted[0];
            MessageBoxPause scriptPause = GetComponent<MessageBoxPause>();
            string valueChoice = lineSplitted[1];
            //newChoice.GetComponent<Button>().onClick.AddListener(delegate { scriptPause.MakingChoice(valueChoice); });
            //newChoice.GetComponent<Button>().onClick.AddListener(()=>
            /*newChoice.GetComponent<Button>().onClick.AddListener(new UnityAction(() =>
            {
                //scriptPause.MakingChoice(valueChoice);
            }));*/

            CallEventChoice scriptButton = newChoice.GetComponent<CallEventChoice>();
            scriptButton.choice_label = valueChoice;
            scriptButton.msgBox = msgBox;
            newChoice.SetActive(true);
            Instantiate(newChoice, parent);
            pos++;
        }
        return pos;
    }

}
