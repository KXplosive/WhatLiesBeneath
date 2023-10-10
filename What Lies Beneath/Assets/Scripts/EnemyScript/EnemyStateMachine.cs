using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public EnemyBase enemy;

    public enum BattleState
    {
        ACTIONABLE,
        UNACTIONABLE,
        ACTION,
        DEAD
    }

    public BattleState currentBattleState;

    // Start is called before the first frame update
    void Start()
    {
        enemy.currentHP = enemy.baseHP;
        enemy.currentAttack = enemy.Attack;
        enemy.currentDefense = enemy.Defense;
        currentBattleState = BattleState.UNACTIONABLE;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.currentHP <= 0)
        {
            currentBattleState = BattleState.DEAD;
            GetComponent<Renderer>().material.color = new Color ( 0.5f, 0.5f, 0.5f,1f);
            Destroy(gameObject,4);
        }
    }
}
