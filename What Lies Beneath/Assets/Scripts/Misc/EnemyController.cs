using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemySpawner spawner;
    List<Enemy> enemies;
    List<Enemy> turns; // comportamiento de queue
    // Start is called before the first frame update
    private bool play = false;
    void Start()
    {
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
            if(turns.Count == 0)
            {

            }
            else
            {
                NextTurn(turns[0]);
                play = true;
            }
        }
    }

    public void NextTurn(Enemy turn)
    {
        // pop del siguiente en la lista de turns
        Enemy nextEnemy = turns[0];
        turns.RemoveAt(0);
        // pop.setBehavior(attackBehavior);
        nextEnemy.SetBehavior(new Default());
    }

    public void EnemyDeath(Enemy enemy)
    {
        // Quitar especifico de la lista de enemies
        enemies.Remove(enemy);
        // Asegurar que no exista especifico de la lista de turns
        turns.Remove(enemy);
    }

    public void EndOfEnemyTurn(Enemy enemy)
    {
        // atb = active time battle
        // enemy atb (time counter)
        enemy.SetBehavior(new ATBSleep());
    }

    public void ATBcomplete(Enemy enemy)
    {
        // agregar a la lista de turns
        turns.Add(enemy);
    }
}
