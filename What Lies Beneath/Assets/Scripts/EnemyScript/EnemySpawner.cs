using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    //public EnemyGroup[] enemyGroups;
    public EnemyGroup enemiesSelected;
    public GameObject nextButton;

    Vector3[] positions = { new Vector3(2f, -1.5f), new Vector3(4.2f, 0f), new Vector3(5f, -3f), new Vector3(7.25f, -1.5f) };
    // HACER UN CUSTOM INSPECTOR PARA ESTA CLASE

    int numOrdas;

    // Start is called before the first frame update
    void Awake()
    {
        nextButton.SetActive(false);
        if (enemiesSelected.Type == EnemyGroup.groupType.COMBATE)
        {
            numOrdas = 1;
        }
        else if (enemiesSelected.Type == EnemyGroup.groupType.ELITE)
        {
            numOrdas = 2;
        }
        else if (enemiesSelected.Type == EnemyGroup.groupType.HORDA)
        {
            numOrdas = 3;
        }
        else
        {
            Debug.Log("HEY, ALGO MALO PASO AQUI");
        }
        // spawnear a los enemgos
        for (int i = 0; i < enemiesSelected.enemies.Length; i++)
        {
            Instantiate(enemiesSelected.enemies[i],positions[i],Quaternion.identity);
        }
        numOrdas -= 1;
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
        if (!enemiesAlive()){
            nextButton.SetActive(true);
        }
    }

    bool enemiesAlive()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length >= 1;
    }
}

