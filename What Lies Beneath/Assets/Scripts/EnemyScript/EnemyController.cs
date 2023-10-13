using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemySpawner spawner;
    List<Enemy> enemies;
    List<Enemy> turns; // comportamiento de queue
    private Enemy currentTurn;
    // Start is called before the first frame update
    private bool play = false;
    void Start()
    {
        spawner = GetComponent<EnemySpawner>();
        // Pedir al manager los spawns de enemies
        // Pasar a todos los enemies de lista "enemies" el EnemyControlles(this)
        enemies = spawner.GetEnemies(this);
        /*foreach(var enemy in enemies)
        {
            turns.var = enemies;
        }*/


    }

    // Update is called once per frame
    void Update()
    {
        if (!play)
        {
            if (!(turns.Count == 0))
            {
                NextTurn();
            }
        }
    }

    public void NextTurn()
    {
        // pop del siguiente en la lista de turns
        currentTurn = turns[0];
        turns.RemoveAt(0);
        // pop.setBehavior(attackBehavior);
        currentTurn.SetBehavior(new Default());
        play = true;
    }

    public void EnemyDeath(Enemy enemy)
    {
        // Quitar especifico de la lista de enemies
        enemies.Remove(enemy);
        // Asegurar que no exista especifico de la lista de turns
        if (turns.Contains(enemy))
            turns.Remove(enemy);

        if (enemies.Count == 0) 
        { 
            //end of fight - NextEvent, Forward!!!
        }

    }

    public void EndOfEnemyTurn(Enemy enemy)
    {
        // atb = active time battle
        // enemy atb (time counter)
        enemy.SetBehavior(new ATBSleep());
        play = false;
    }

    // Eventualmente se tiene que solucionar que cuando ataca el jugador todos los contadores ATB se paran
    public void ATBcomplete(Enemy enemy)
    {
        // agregar a la lista de turns
        turns.Add(enemy);
    } 
}
