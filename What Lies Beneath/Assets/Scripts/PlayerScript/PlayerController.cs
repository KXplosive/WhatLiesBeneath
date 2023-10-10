using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HeroStateMachine stateMachine;
    public GameObject[] enemies;
    public GameObject cursor;
    EnemyStateMachine[] enemiesState;

    PersonajeBase character;
    int enemySelected;

    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemySelected=-1;
        character = stateMachine.character;
        enemiesState = new EnemyStateMachine[enemies.Length];
        for(int i = 0; i < enemies.Length; i++)
        {
            enemiesState[i] = enemies[i].GetComponent<EnemyStateMachine>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stateMachine.currentBattleState == HeroStateMachine.BattleState.WAITING)
        {
            if (Input.GetKeyDown("j"))
            {
                if (enemiesState[0].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 0;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }
            }
            else if (Input.GetKeyDown("i"))
            {
                if (enemiesState[1].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 1;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }

            }
            else if (Input.GetKeyDown("o"))
            {
                if (enemiesState[2].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 2;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }

            }
            else if (Input.GetKeyDown("p"))
            {
                if (enemiesState[2].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 3;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }
            }

            if (Input.GetKeyDown("1") && enemySelected!=-1)
            {
                stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                StartCoroutine(Attacking(character.attacks[0], enemiesState[enemySelected]));
            }
            else if (Input.GetKeyDown("2") && enemySelected != -1)
            {
                stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                StartCoroutine(Attacking(character.attacks[1], enemiesState[enemySelected]));
            }
            else if (Input.GetKeyDown("3") && enemySelected != -1)
            {
                stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                StartCoroutine(Attacking(character.attacks[2], enemiesState[enemySelected]));
            }
            
        }
       
    }

    IEnumerator Attacking(Attack attack, EnemyStateMachine enemy)
    {
        stateMachine.character.currentST -= attack.ST * (-0.5f*stateMachine.temperatureModifiers[1]);
        stateMachine.character.temperature += attack.temperatureChange;
        for (float i = 0f; i <= attack.startup; i += 1 * Time.deltaTime)
        {
            yield return null;
        }
        enemy.enemy.currentHP -= DamageCalc(stateMachine.character.currentAttack, enemy.enemy.currentDefense, attack.baseDamage);
        yield return null;
        if (enemy.currentBattleState == EnemyStateMachine.BattleState.DEAD)
        {
            enemySelected = -1;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));

        }
        for (float i = 0f; i <= attack.ending; i += 1 * Time.deltaTime)
        {
            yield return null;
        }

        if (stateMachine.currentBattleState != HeroStateMachine.BattleState.TIRED)
        {
            stateMachine.currentBattleState = HeroStateMachine.BattleState.WAITING;
        }
        yield return null;
    }

    float DamageCalc(float attack, float defense, int baseAttack)
    {
        return baseAttack * (defense / 100) / (attack / 50);
    }
}
