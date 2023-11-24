using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.Animations.Rigging;

public class PlayerControllerFSM : MonoBehaviourPunCallbacks
{
    [System.NonSerialized]
    public GameObject[] enemies;

    [HideInInspector]
    public int id;

    [Header("Components")]
    public Player photonPlayer;


    public GameObject cursor;

    PhotonView view;

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
    public readonly Win WinState = new Win();

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
        if(ScenesManager.sceneOrder[ScenesManager.currentScene] == 4)
        {
            TransitionToState(WinState);
        }
        else
        {
            TransitionToState(IdleState);
        }
        enemySelected = -1;

        view = GetComponent<PhotonView>();
        // if view is mine poner componente main player
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            //enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemySelected > -1)
            {
                enemySelectedGO = enemies[enemySelected];
            }
            currentState.Update(this);

        }
    }

    // Inicializar la informacion del player actual
    [PunRPC]
    public void Init(Player player)
    {
        photonPlayer = player;// Asiganar el player actual
        id = player.ActorNumber;//Guardar el id del player
        SpawnPlayers.instance.players[id - 1] = this;// Asiganarlo a las lista de player dentro del game controller
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    private void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }

    internal void TransitionToState(PlayerBaseState playerState)
    {
        currentState = playerState;
        currentState.EnterState(this);
    }

    string[] animations = { "Idle", "DashNoMovement", "Attack", "ReturnNoMovement","Victory" };
    public enum AnimatorTriggerStates { Idle = 0, DashNoMovement = 1, Attack = 2, Return = 3, Win = 4};

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
