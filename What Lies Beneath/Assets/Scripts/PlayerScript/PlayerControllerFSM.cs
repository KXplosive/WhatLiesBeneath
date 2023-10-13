using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerFSM : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject[] enemies;

    public GameObject cursor;

    [System.NonSerialized]
    public HeroStateMachine stateMachine;
    [System.NonSerialized]
    public MonsterB[] monsterB;
    [System.NonSerialized]
    public int enemySelected;
    [System.NonSerialized]
    public GameObject enemySelectedGO;

    [System.NonSerialized]
    public int attackSelected;

    [System.NonSerialized]
    public Vector3 startingPosition;

    private Animator animator;
    public Animator Animator
    {
        get { return animator; }
    }

    private PlayerBaseState currentState;
    public PlayerBaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly Idle IdleState = new Idle();
    public readonly Running RunningState = new Running();
    public readonly Attacking AttackState = new Attacking();
    public readonly Returning ReturnState = new Returning();

    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        
        startingPosition = gameObject.transform.position;
    }
    /*
    public void LoadMosters()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        monsterB = new MonsterB[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            monsterB[i] = enemies[i].GetComponent<MonsterB>();
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        stateMachine = gameObject.GetComponent<HeroStateMachine>();
        monsterB = new MonsterB[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            monsterB[i] = enemies[i].GetComponent<MonsterB>();
        }
        enemySelected = -1;
        TrasitionToState(IdleState);
    }

    // Update is called once per frame
    void Update()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemySelected > -1)
        {
            enemySelectedGO = enemies[enemySelected];
        }
        currentState.Update(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    private void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }

    internal void TrasitionToState(PlayerBaseState playerState)
    {
        currentState = playerState;
        currentState.EnterState(this);
    }

    public enum AnimatorTriggerStates { Idle = 0, DashNoMovement = 1, Attack = 2, Return = 3};
    public void SetAnimatorTrigger(AnimatorTriggerStates state)
    {
        animator.SetInteger("anim", (int)state);
    }

    public void DestroyGO(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void CreateCursor()
    {
        Instantiate(cursor, new Vector3(enemies[enemySelected].transform.position.x, enemies[enemySelected].transform.position.y), Quaternion.identity);
    }
}
