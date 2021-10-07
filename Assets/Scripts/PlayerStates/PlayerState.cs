using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Player player;
    public states state;
    public InputManager inputManager;
    public enum states
    {
        IDLE,
        ACTION,
        INTERACTION,
        WALK,
        RUN,
        HITTED,
        DEATH
    }
    private void Awake()
    {
        player = GetComponent<Player>();
        inputManager = GetComponent<InputManager>();
    }

    public virtual void Init()
    {
    }
}
