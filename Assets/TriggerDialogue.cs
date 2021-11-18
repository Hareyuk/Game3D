using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public MessageBox msgBox;
    public TextAsset file;
    public List<Animator> AnimCharacters;
    public bool destroyIt;
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = this.gameObject;
        if(other.name == "DogPBR_Mine")
        {
            foreach (Animator animChara in AnimCharacters)
            {
                animChara.speed = 0;
            }
            msgBox.ExecuteEventMessage(file, AnimCharacters, go);
        }
    }
}
