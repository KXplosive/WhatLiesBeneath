using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public EnemyGroup[] enemyGroups;
    public EnemyGroup enemiesSelected;
    // HACER UN CUSTOM INSPECTOR PARA ESTA CLASE

    int numOrdas;

    // Start is called before the first frame update
    void Awake()
    {
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
            Instantiate(enemiesSelected.enemies[i]);
        }
        numOrdas -= 1;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
