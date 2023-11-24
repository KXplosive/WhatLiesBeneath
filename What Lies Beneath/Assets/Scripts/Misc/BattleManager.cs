using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static bool battleInProgress = false;

    GameObject[] players;
    GameObject[] enemies;

    public NameUI nameUI;
    public TemperatureUI temperatureUI;
    public MonsterController monsterController;

    public GameObject nextEncounterBtn;
    /*
     Orden de las acciones
    Spawnear enemigos
    Spawnear juegdores
    Iniciar combate
    Al ganar combate pasar a victoria
    Pasar a siguiente encuentro
     */
    private void Awake()
    {
        nextEncounterBtn.SetActive(false);
        //spawn players
        players = GameObject.FindGameObjectsWithTag("Player");
        //set ui variables
        //spawn enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        battleInProgress = true;
    }

    private void Update()
    {
        if(monsterController.numEnemies <= 0)
        {
            winBattle();
        }
        if (!arePlayersAlive())
        {
            loseBattle();
        }
    }

    public void winBattle()
    {
        //victory animation
        nextEncounterBtn.SetActive(true);
    }

    public bool arePlayersAlive()
    {
        foreach(GameObject player in players)
        {
            if (player.GetComponent<HeroStateMachine>().character.currentHP > 0)
            {
                return true;
            }
        }
        return false;
    }

    public void loseBattle()
    {
        //go back to encounter1
        Debug.Log("You Lose");
        ScenesManager.currentScene = -1;
        SceneManager.LoadScene(6);
    }
}
