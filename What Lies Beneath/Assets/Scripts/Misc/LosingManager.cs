using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosingManager : MonoBehaviour
{
    GameObject player;
    PlayerControllerFSM playerController;


    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerControllerFSM>();
        playerController.TransitionToState(playerController.LoseState);
    }

    private void Start()
    {
        playerController = player.GetComponent<PlayerControllerFSM>();
        playerController.TransitionToState(playerController.LoseState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
