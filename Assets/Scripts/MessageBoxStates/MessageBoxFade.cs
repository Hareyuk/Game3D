using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBoxFade : MessageBoxState
{
    public float speed;
    public override void Init()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (msgBox.msgImage.localPosition.y > -800)
        {
            Vector3 moveImg = -msgBox.msgImage.up * speed;
            msgBox.msgImage.Translate(Time.deltaTime * moveImg);
        }
        else
        {
            msgBox.ReanudeAnimationCharacters();
            msgBox.SetNewState(MessageBoxState.states.OUT);
        }
    }
}
