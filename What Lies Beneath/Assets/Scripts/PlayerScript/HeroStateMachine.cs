using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour
{
    public PersonajeBase character;
    public EnemyStateMachine[] enemies;

    public enum BattleState
    {
        WAITING,
        ACTION,
        DEAD,
        TIRED,
        FREEZE
    }

    public enum TemperatureState
    {
        UNASSIGNED,
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
    public TemperatureState previousTemperatureState;

    public float[] temperatureModifiers = {0f, 0f, 0f, 0f}; // mp, st, atk, def

    // Start is called before the first frame update
    void Start()
    {

        currentBattleState = BattleState.WAITING;
        character.currentHP = character.baseHP;
        character.currentMP = character.baseMP;
        character.currentST = character.baseST;
        character.currentAttack = character.attack;
        character.currentDefense = character.defense;
        StartCoroutine(RecoverST(character));
        previousTemperatureState = TemperatureState.UNASSIGNED;
    }

    // Update is called once per frame
    void Update()
    {
        character.currentAttack = character.attack * (1+temperatureModifiers[2]);
        character.currentDefense = character.defense * (1+temperatureModifiers[3]);
        switch (currentBattleState)
        {
            case (BattleState.WAITING):
                /*
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
                */
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
            case >=70:
                currentTemperatureState = TemperatureState.SCORCHING;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = 0f;
                    temperatureModifiers[1] = 0f;
                    temperatureModifiers[2] = 0f;
                    temperatureModifiers[3] = 0f;
                    StartCoroutine(Scorching());
                    previousTemperatureState = currentTemperatureState;
                }
            break;
            case >=56 and <=69:
                currentTemperatureState = TemperatureState.HIGH;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = -0.5f;
                    temperatureModifiers[1] = 0f;
                    temperatureModifiers[2] = 0f;
                    temperatureModifiers[3] = -0.5f;
                    previousTemperatureState = currentTemperatureState;
                }
                break;
            case >= 41 and <= 55:
                currentTemperatureState = TemperatureState.MODERATE;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = 0f;
                    temperatureModifiers[1] = -0.5f;
                    temperatureModifiers[2] = 0f;
                    temperatureModifiers[3] = 0f;
                    previousTemperatureState = currentTemperatureState;
                }
                break;
            case >= 31 and <= 40:
                currentTemperatureState = TemperatureState.REGULAR;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = 0.5f;
                    temperatureModifiers[1] = 0.5f;
                    temperatureModifiers[2] = 0.5f;
                    temperatureModifiers[3] = 0.5f;
                    previousTemperatureState = currentTemperatureState;
                }
                break;
            case >= 16 and <= 30:
                currentTemperatureState = TemperatureState.REDUCED;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = 0f;
                    temperatureModifiers[1] = -0.5f;
                    temperatureModifiers[2] = 0f;
                    temperatureModifiers[3] = 0f;
                    previousTemperatureState = currentTemperatureState;
                }
                break;
            case >= 1 and <= 15:
                currentTemperatureState = TemperatureState.LOW;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = 0f;
                    temperatureModifiers[1] = 0f;
                    temperatureModifiers[2] = -0.5f;
                    temperatureModifiers[3] = -0.5f;
                    previousTemperatureState = currentTemperatureState;
                }
                break;
            case <=0:
                currentTemperatureState = TemperatureState.FREEZING;
                if (previousTemperatureState != currentTemperatureState)
                {
                    temperatureModifiers[0] = -0.5f;
                    temperatureModifiers[1] = -0.5f;
                    temperatureModifiers[2] = -0.5f;
                    temperatureModifiers[3] = -0.5f;
                    previousTemperatureState = currentTemperatureState;
                    StartCoroutine(Freezing());
                }
                break;
        }

        if (character.currentST <= 0)
        {
            currentBattleState = BattleState.TIRED;
        }
        /*
        if (Input.GetKeyDown("j"))
        {
            enemySelected = 0;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(5.82f, -2.77f), Quaternion.identity);
        }
        if (Input.GetKeyDown("i"))
        {
            enemySelected = 1;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(1.51f, -3.01f), Quaternion.identity);
        }
        if (Input.GetKeyDown("o"))
        {
            enemySelected = 2;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(1.34f, 0.15f), Quaternion.identity);
        }
        if (Input.GetKeyDown("p"))
        {
            enemySelected = 3;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));
            Instantiate(cursor, new Vector3(5.71f, 0.25f), Quaternion.identity);
        }
        */
        

    }
    /*
    IEnumerator Attacking(Attack attack,EnemyStateMachine enemy,PersonajeBase character)
    {
        character.currentST -= attack.ST;
        character.temperature += attack.temperatureChange;
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
    */

    IEnumerator Freezing()
    {
        while (currentBattleState != BattleState.WAITING)
        {
            yield return null;
        }
        currentBattleState = BattleState.FREEZE;
        yield return null;
        for(float i=0f; i < 3; i += Time.deltaTime)
        {
            yield return null;
        }
        currentBattleState = BattleState.WAITING;
        yield return null;
    }

    IEnumerator Scorching()
    {
        float dmg = 0f;
        while (currentTemperatureState == TemperatureState.SCORCHING)
        {
            dmg += 0.0001f* Time.deltaTime;
            character.currentHP -= dmg;
            yield return null;

        }
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
