using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHPRest : MonoBehaviour
{
    public HeroStateMachine[] stateMachine;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < stateMachine.Length; i++)
        {
            stateMachine[i].character.currentHP = stateMachine[i].character.baseHP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
