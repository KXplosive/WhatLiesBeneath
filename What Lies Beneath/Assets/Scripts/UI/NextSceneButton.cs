using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextSceneButton : MonoBehaviour
{
    public Button nextSceneButton;
    public HeroStateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneButton.onClick.AddListener(nextScene);
    }

    private void nextScene()
    {
        //ScenesManager.Instance.currentHP = stateMachine.character.currentHP;
        ScenesManager.currentHP = stateMachine.character.currentHP;
        ScenesManager.temperature = stateMachine.character.temperature;
        ScenesManager.Instance.loadNextScene(stateMachine);
    }
}
