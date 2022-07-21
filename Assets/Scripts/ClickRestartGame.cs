using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClickRestartGame : MonoBehaviour
{
    public bool restartGame = false;
    public InputManager inputManager;
    void Update()
    {
        if (restartGame)
        {
            if (inputManager.pressingMouseLeftButton)
            {
                SceneManager.LoadScene("PrincFinal");
            }
        }
    }

    public void enableClickRestart()
    {
        restartGame = true;
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
        inputManager = gos[0].GetComponent<InputManager>();
        GetComponent<Animator>().Play("UIShowed");
    }
}
