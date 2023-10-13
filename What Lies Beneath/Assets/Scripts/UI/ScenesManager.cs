using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Fight,
        Rest,
        Boss
    }

    int[] sceneOrder = {1, 1, 2, 1, 1, 2, 3,0 };
    public static int currentScene = -1;

    public static float currentHP;

    public static float temperature;

    public void loadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void loadBattle()
    {
        SceneManager.LoadScene(Scene.Fight.ToString());
    }

    public void loadNextScene(HeroStateMachine stateMachine)
    {
        currentScene++;
        if (currentScene == sceneOrder.Length)
        {
            currentScene = 0;
        }
        if (currentScene == 0)
        {
            currentHP = stateMachine.character.baseHP;
            temperature = 35;
        }
        SceneManager.LoadScene(sceneOrder[currentScene]);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }
}
