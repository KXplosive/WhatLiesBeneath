using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBehavior attackBehavior = new Default();
    private EnemyBehavior currentState;
    public EnemyBase enemyBase;
    public EnemyController ec;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetBehavior(new ATBSleep());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this);
    }

    /*public void startBattle()
    {
        currentState.EnterState(this);
    }*/

    public void SetBehavior(EnemyBehavior behaviour)
    {
        currentState = behaviour;
        currentState.EnterState(this);
    }

}
