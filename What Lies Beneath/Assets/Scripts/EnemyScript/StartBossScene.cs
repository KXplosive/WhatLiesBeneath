using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class StartBossScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerFSM playerFSM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerFSM>();
        Array.Clear(playerFSM.enemies, 0, playerFSM.enemies.Length);
        playerFSM.newScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
