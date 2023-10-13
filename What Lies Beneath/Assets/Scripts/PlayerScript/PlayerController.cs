using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public HeroStateMachine stateMachine;
    GameObject[] enemies;
    public GameObject cursor;
    EnemyStateMachine[] enemiesState;

    PersonajeBase character;
    int enemySelected;
    public float distanciaEnemigos;

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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (enemiesState[0].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 0;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (enemiesState[1].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 1;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (enemiesState[2].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 2;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (enemiesState[2].currentBattleState != EnemyStateMachine.BattleState.DEAD)
                {
                    enemySelected = 3;
                    Destroy(GameObject.FindGameObjectWithTag("Cursor"));
                    Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
                }
            }
            //Input.GetButton("Fire1");
            if (Input.GetKeyDown("1") && enemySelected!=-1)
            {
                stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                StartCoroutine(Attacking(character.attacks[0], enemies[enemySelected]));
            }
            else if (Input.GetKeyDown("2") && enemySelected != -1)
            {
                stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                StartCoroutine(Attacking(character.attacks[1], enemies[enemySelected]));
            }
            else if (Input.GetKeyDown("3") && enemySelected != -1)
            {
                stateMachine.currentBattleState = HeroStateMachine.BattleState.ACTION;
                StartCoroutine(Attacking(character.attacks[2], enemies[enemySelected]));
            }
            
        }
       
    }

    IEnumerator Attacking(Attack attack, GameObject enemy)
    {
        stateMachine.character.currentST -= attack.ST * (-0.5f*stateMachine.temperatureModifiers[1]);
        stateMachine.character.temperature += attack.temperatureChange;
        EnemyStateMachine enemyState = enemy.GetComponent<EnemyStateMachine>();
        Vector3 ogPosition = gameObject.transform.position;
        float posX;
        float posY;
        float speed = 10f;

        // el jugador se mueve hacia el enemigo
        while (gameObject.transform.position.x < enemy.transform.position.x - distanciaEnemigos && gameObject.transform.position.y != enemy.transform.position.y)
        {
            if(gameObject.transform.position.x < enemy.transform.position.x - distanciaEnemigos)
            {
                posX = gameObject.transform.position.x + speed * Time.deltaTime;
            }
            else
            {
                posX = gameObject.transform.position.x;
            }
            if(gameObject.transform.position.y < enemy.transform.position.y)
            {
                posY = gameObject.transform.position.y + speed * Time.deltaTime;
            } else if (gameObject.transform.position.y > enemy.transform.position.y)
            {
                posY = gameObject.transform.position.y - speed * Time.deltaTime;
            }
            else
            {
                posY = gameObject.transform.position.y;
            }
            gameObject.transform.position = new Vector3(posX, posY);
            yield return null;

        }

        // el jugador realiza el ataque
        enemyState.enemy.currentHP -= DamageCalc(stateMachine.character.currentAttack, enemyState.enemy.currentDefense, attack.baseDamage);
        if (enemyState.currentBattleState == EnemyStateMachine.BattleState.DEAD)
        {
            enemySelected = -1;
            Destroy(GameObject.FindGameObjectWithTag("Cursor"));

        }
        yield return null;
        for (float i = 0; i<3;i += Time.deltaTime)
        {
            yield return null;
        }

        float distX = Mathf.Abs(gameObject.transform.position.x - ogPosition.x)*5;
        float distY = Mathf.Abs(gameObject.transform.position.y - ogPosition.y)*5;

        // el jugador regresa a la posicion original
        while (gameObject.transform.position.x != ogPosition.x && gameObject.transform.position.y != ogPosition.y)
        {
            posX = gameObject.transform.position.x - distX * Time.deltaTime;
            if (posX < ogPosition.x)
            {
                posX = ogPosition.x;
            }
            if (gameObject.transform.position.y > ogPosition.y)
            {
                posY = gameObject.transform.position.y - distY * Time.deltaTime;
                if(posY< ogPosition.y)
                {
                    posY = ogPosition.y;
                }
            }else if (gameObject.transform.position.y < ogPosition.y)
            {
                posY = gameObject.transform.position.y + distY * Time.deltaTime;
                if (posY > ogPosition.y)
                {
                    posY = ogPosition.y;
                }
            }
            else
            {
                posY = ogPosition.y;
            }
            gameObject.transform.position = new Vector3(posX, posY);

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
