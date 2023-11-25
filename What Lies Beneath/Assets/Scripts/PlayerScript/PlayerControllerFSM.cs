using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerControllerFSM : MonoBehaviour
{
    public GameObject[] enemies;

    [HideInInspector]
    public int id;

    [Header("Components")]
    public Player photonPlayer;

    PhotonView view;

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

    //ItemBase[] potions = { new HealingPotion() , new ManaPotion(), new StaminaPotion()};
    public Inventory inventory = new Inventory();
    public Potions potions;
    public int gold = 0;

    public readonly Idle IdleState = new Idle();
    public readonly Running RunningState = new Running();
    public readonly Attacking AttackState = new Attacking();
    public readonly Returning ReturnState = new Returning();
    public readonly Win WinState = new Win();
    public readonly Lose LoseState = new Lose();
    public bool newScene = false;
    private void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        
        startingPosition = gameObject.transform.position;
        potions = gameObject.GetComponent<Potions>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        view = GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (newScene)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            stateMachine = gameObject.GetComponent<HeroStateMachine>();

            monsterB = new MonsterB[enemies.Length];
            for (int i = 0; i < enemies.Length; i++)
            {
                monsterB[i] = enemies[i].GetComponent<MonsterB>();
            }
            if (ScenesManager.currentScene == -1)
            {
                TransitionToState(LoseState);
            }
            else if (ScenesManager.sceneOrder[ScenesManager.currentScene] == 4)
            {
                TransitionToState(WinState);
            }
            else
            {
                TransitionToState(IdleState);
            }
            enemySelected = -1;
            newScene = false;
        }
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

    public void TransitionToState(PlayerBaseState playerState)
    {
        currentState = playerState;
        currentState.EnterState(this);
    }

    string[] animations = { "Idle", "DashNoMovement", "Attack", "ReturnNoMovement","Victory" ,"Faint"};
    public enum AnimatorTriggerStates { Idle = 0, DashNoMovement = 1, Attack = 2, Return = 3, Win = 4,Faint = 5};

    public void SetAnimatorTrigger(AnimatorTriggerStates state)
    {
        //animator.SetInteger("anim", (int)state);
        animator.Play(animations[(int)state]);
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
