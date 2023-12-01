using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{
    GameObject[] deletePlayer;
    public void ChangeMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ChangeNewRun()
    {
        SceneManager.LoadScene("New Run");
    }
    public void ChangeContinue()
    {
        SceneManager.LoadScene("Continue");
    }
    public void ChangeCoOp()
    {
        SceneManager.LoadScene("Co-Op");
    }
    public void ChangeCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ChangeSetting()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ChangeBattle()
    {
        SceneManager.LoadScene("Battle");
    }

    public void Back2MainMenu()
    {
        deletePlayer = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in deletePlayer)
        {
            Destroy(go);
        }
        Variables.contEventos = 0;
        Variables.contNivel = 0;
        Variables.contPosNeg = 2;
        Variables.contEnemigos = 4;
        SceneManager.LoadScene("Main Menu");
    }

}
