using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class EnemySpawner : MonoBehaviour
{

    public BattleGroup[] enemyGroups;
    public EnemyGroup enemies;

    BattleGroup battleGroup;

    //public EnemyGroup[] enemyGroups;
    public EnemyGroup enemiesSelected;
    public GameObject nextButton;
    public List<GameObject> enemiesGO;
    public PlayerControllerFSM player;
    public GameObject[] players;
    public GameObject playerGO;
    public GameObject playerGO2;
    //private PlayerControllerFSM P1;

    Vector3[] positions = { new Vector3(2f, -1.5f), new Vector3(4.2f, 0f), new Vector3(5f, -3f), new Vector3(7.25f, -1.5f) };

    int numOrdas;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            DontDestroyOnLoad(Instantiate(playerGO));
            DontDestroyOnLoad(Instantiate(playerGO2, new Vector2(-2f, -3f), Quaternion.identity));
        }

        players = GameObject.FindGameObjectsWithTag("Player");
        enemyGroups = AreaController.Instance.groups[AreaController.Instance.area - 1];
        battleGroup = enemyGroups[UnityEngine.Random.Range(0, enemyGroups.Length)];

        // spawnear a los enemgos
        for (int i = 0; i < battleGroup.enemies.Length; i++)
        {
            enemiesGO.Add(Instantiate(battleGroup.enemies[i], positions[i], Quaternion.identity));
        }
        numOrdas -= 1;
        foreach(GameObject pl in players)
        {
            pl.GetComponent<PlayerControllerFSM>().enemies = enemiesGO.ToArray();
        }
        PlayerControllerFSM playerFSM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerFSM>();
        Array.Clear(playerFSM.enemies, 0, playerFSM.enemies.Length);
        playerFSM.newScene = true;
        //P1.LoadMosters();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (numOrdas > 0)// y tondos los enemigos estan muertos
        {
            for (int i = 0; i < enemiesSelected.enemies.Length; i++)
            {
                Instantiate(enemiesSelected.enemies[i]);
            }
        }
        else
        {
            //ganar encuentro
        }
        */
        /*if (!enemiesAlive()){
            nextButton.SetActive(true);
        }*/
    }

    bool enemiesAlive()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length >= 1;
    }
}
