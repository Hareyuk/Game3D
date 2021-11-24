using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDeath : PlayerState
{
    // Animator UIGameOver;
    public Transform parentUI;
    public GameObject prefabGOUI;
    public override void Init()
    {
        player.anim.Play("Die");
    }

    public void EnableScreenGameOver()
    {
        Instantiate(prefabGOUI, parentUI);
        //UIGameOver.Play("Showing");
    }
}
