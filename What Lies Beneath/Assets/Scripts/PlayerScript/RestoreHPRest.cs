using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHPRest : MonoBehaviour
{
    public HeroStateMachine[] stateMachine;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<HeroStateMachine>().character.currentHP = player.GetComponent<HeroStateMachine>().character.baseHP;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
