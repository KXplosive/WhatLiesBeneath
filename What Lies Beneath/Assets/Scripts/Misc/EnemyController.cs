using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    List<Enemy> enemies;
    List<Enemy> turns; // comportamiento de queue
    // Start is called before the first frame update
    void Start()
    {
        // Pedir al manager los spawns de enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Pasar a todos los enemies de lista "enemies" el EnemyControlles(this)
        turns = new List<Enemy>();
        foreach(var enemy in enemies)
        {
            enemy.SetBehavior(new ATBSleep());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDeath(Enemy enemy)
    {
        // Quitar especifico de la lista de enemies
        // Asegurar que no exista especifico de la lista de turns
    }

    public void EndOfEnemyTurn(Enemy enemy)
    {
        // atb = active time battle
        // enemy atb (time counter)
        enemy.SetBehavior(new ATBSleep());
        // pop del siguiente en la lista de turns
        // pop.setBehavior(attackBehavior);
    }

    public void ATBcomplete(Enemy enemy)
    {
        // agregar a la lista de turns
    }
}
