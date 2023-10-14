using System.Collections;
using UnityEngine;

public class MonsterB : MonoBehaviour
{
    /*Spawn Enemies
Enemy Attacks
Enemy Stamina or timeloop for attacks to happen
Animator CHECK SLIDES
CHECK IF CODE CAN BE APPLIED*/
    public MonsterController monsterC;
    public EnemyBase enemyBase;
    public float attackDistance;
    // public GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        monsterC = GameObject.FindGameObjectWithTag("Monster Controller").GetComponent<MonsterController>();
        enemyBase.currentHP = enemyBase.baseHP;
        enemyBase.currentAttack = enemyBase.Attack;
        enemyBase.currentDefense = enemyBase.Defense;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyBase.currentHP <= 0)
        {
            // SEND CALL FOR DEATH
            monsterC.RemoveMe(gameObject);

            // Destroys the object in 2 seconds
            Destroy(gameObject);

            // Death animation 


        }
    }


    public IEnumerator Attacking(GameObject player)
    {
        HeroStateMachine heroState = player.GetComponent<HeroStateMachine>();
        Vector3 ogPosition = gameObject.transform.position;
        float posX;
        float posY;
        float speed = 10f;

        // el monstruo se mueve hacia el jugador
        while (gameObject.transform.position.x > player.transform.position.x + attackDistance && gameObject.transform.position.y != player.transform.position.y)
        {
            if (gameObject.transform.position.x > player.transform.position.x + attackDistance)
            {
                posX = gameObject.transform.position.x - speed * Time.deltaTime;
            }
            else
            {
                posX = gameObject.transform.position.x;
            }
            if (gameObject.transform.position.y < player.transform.position.y)
            {
                posY = gameObject.transform.position.y + speed * Time.deltaTime;
            }
            else if (gameObject.transform.position.y > player.transform.position.y)
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

        // animacion de ataque

        // el monstruo realiza el ataque
        heroState.character.currentHP -= 7.5f;
        yield return null;



        for (float i = 0; i < 3; i += Time.deltaTime)
        {
            yield return null;
        }

        float distX = Mathf.Abs(gameObject.transform.position.x - ogPosition.x) * 5;
        float distY = Mathf.Abs(gameObject.transform.position.y - ogPosition.y) * 5;

        // el monstruo regresa a la posicion original
        while (gameObject.transform.position.x != ogPosition.x && gameObject.transform.position.y != ogPosition.y)
        {
            posX = gameObject.transform.position.x + distX * Time.deltaTime;
            if (posX > ogPosition.x)
            {
                posX = ogPosition.x;
            }
            if (gameObject.transform.position.y > ogPosition.y)
            {
                posY = gameObject.transform.position.y - distY * Time.deltaTime;
                if (posY < ogPosition.y)
                {
                    posY = ogPosition.y;
                }
            }
            else if (gameObject.transform.position.y < ogPosition.y)
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

        // Back to Idle


        yield return null;
    }

}
