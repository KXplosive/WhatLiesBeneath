using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour
{
    public PersonajeBase character;
    public GameObject temperatureController;
    public EnemyStateMachine[] enemies;
    public GameObject cursor;

    public enum BattleState
    {
        WAITING,
        ACTION,
        DEAD,
        TIRED
    }

    public enum TemperatureState
    {
        SCORCHING,
        HIGH,
        MODERATE,
        REGULAR,
        REDUCED,
        LOW,
        FREEZING
    }

    public BattleState currentBattleState;
    public TemperatureState currentTemperatureState;

    int enemySelected;


    // Start is called before the first frame update
    void Start()
    {
        enemySelected = 0;
        Instantiate(cursor, new Vector3(5.3145f, -2.6514f), Quaternion.identity);
        currentBattleState = BattleState.WAITING;
        character.currentHP = character.baseHP;
        character.currentMP = character.baseMP;
        character.currentST = character.baseST;
        character.currentAttack = character.attack;
        character.currentDefense = character.defense;
        StartCoroutine(RecoverST(character));
    }

    int attackSelected;
    // Update is called once per frame
    void Update()
    {

        switch (currentBattleState)
        {
            case (BattleState.WAITING):
                if (Input.GetKeyDown("1"))
                {
                    currentBattleState = BattleState.ACTION;
                    StartCoroutine(Attacking(character.attacks[0],enemies[enemySelected],character));
                }
                if (Input.GetKeyDown("2"))
                {
                    currentBattleState = BattleState.ACTION;
                    StartCoroutine(Attacking(character.attacks[1], enemies[enemySelected], character));
                }
                if (Input.GetKeyDown("3"))
                {
                    currentBattleState = BattleState.ACTION;
                    StartCoroutine(Attacking(character.attacks[2], enemies[enemySelected], character));
                }
                break;
            case (BattleState.ACTION):

            break;
            case (BattleState.DEAD):

            break;
            case (BattleState.TIRED):

            break;
        }

        switch (character.temperature)
        {
            case 70:
                currentTemperatureState = TemperatureState.SCORCHING;
            break;
            case >=56 and <=69:
                currentTemperatureState = TemperatureState.HIGH;
                break;
            case >= 41 and <= 55:
                currentTemperatureState = TemperatureState.MODERATE;
                break;
            case >= 31 and <= 40:
                currentTemperatureState = TemperatureState.REGULAR;
                break;
            case >= 16 and <= 30:
                currentTemperatureState = TemperatureState.REDUCED;
                break;
            case >= 1 and <= 15:
                currentTemperatureState = TemperatureState.LOW;
                break;
            case 0:
                currentTemperatureState = TemperatureState.FREEZING;
                break;
        }

        
        if (Input.GetKeyDown("j"))
        {
            enemySelected = 0;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(5.3145f, -2.6514f), Quaternion.identity);
        }
        if (Input.GetKeyDown("i"))
        {
            enemySelected = 1;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(0.44f, -2.44f), Quaternion.identity);
        }
        if (Input.GetKeyDown("o"))
        {
            enemySelected = 2;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(0.52f, 2.01f), Quaternion.identity);
        }
        if (Input.GetKeyDown("p"))
        {
            enemySelected = 3;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(5.1528f, 2.0445f), Quaternion.identity);
        }

        

    }

    IEnumerator Attacking(Attack attack,EnemyStateMachine enemy,PersonajeBase character)
    {
        character.currentST -= attack.ST;
        for (float i=0f;i<=attack.startup;i += 1 * Time.deltaTime)
        {
            yield return null;
        }
        enemy.enemy.currentHP -= DamageCalc(character.currentAttack, enemy.enemy.currentDefense, attack.baseDamage);
        yield return null;
        for (float i = 0f; i <= attack.ending; i += 1 * Time.deltaTime)
        {
            yield return null;
        }
  
        if (character.currentST <= 0)
        {
            currentBattleState = BattleState.TIRED;
        }
        else
        {
            currentBattleState = BattleState.WAITING;
        }
        yield return null;
    }

    float DamageCalc(float attack, float defense, int baseAttack)
    {
        Debug.Log(baseAttack);
        Debug.Log(attack);
        Debug.Log(defense);
        return baseAttack * (defense / 100) / (attack / 50);
    }

    IEnumerator RecoverST(PersonajeBase character)
    {
        while (currentBattleState != BattleState.DEAD)
        {
            if (currentBattleState==BattleState.WAITING && character.currentST < 100)
            {
                character.currentST += 2.5f * Time.deltaTime;
                if (character.currentST > 100)
                {
                    character.currentST = 100;
                }
            }else if (currentBattleState == BattleState.TIRED)
            {
                if (character.currentST < 0) { character.currentST = 0; }
                character.currentST += 10f * Time.deltaTime;
                if (character.currentST >=100) { currentBattleState = BattleState.WAITING; }
            }
            yield return null;
        }
    }


}
