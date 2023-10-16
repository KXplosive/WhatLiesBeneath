using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
