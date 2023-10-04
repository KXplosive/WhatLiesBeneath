using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyGroup[] enemyGroups;
    public EnemyGroup enemies;
    // HACER UN CUSTOM INSPECTOR PARA ESTA CLASE

    int numOrdas;

    // Start is called before the first frame update
    void Start()
    {
        if (enemies.Type == EnemyGroup.groupType.COMBATE)
        {
            numOrdas = 1;
        }
        else if (enemies.Type == EnemyGroup.groupType.ELITE)
        {
            numOrdas = 2;
        }
        else if (enemies.Type == EnemyGroup.groupType.HORDA)
        {
            numOrdas = 3;
        }
        else
        {
            Debug.Log("HEY, ALGO MALO PASO AQUI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
