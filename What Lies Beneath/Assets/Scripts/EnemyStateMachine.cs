using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyBase enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy.currentHP = enemy.baseHP;
        enemy.currentAttack = enemy.Attack;
        enemy.currentDefense = enemy.Defense;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.currentHP <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Destroy(gameObject);
        }
    }
}
