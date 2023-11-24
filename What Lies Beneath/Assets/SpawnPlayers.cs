using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    //Instancia (singleton)
    public static SpawnPlayers instance;

    public bool isGameEnd = false;
    public string playerPrefab;

    public Transform[] spawnPositions;
    public PlayerControllerFSM[] players;

    [SerializeField] private int playerInGame;
    
    public UIController uiController;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        players = new PlayerControllerFSM[PhotonNetwork.PlayerList.Length];
        photonView.RPC("InGame", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void InGame()
    {
        playerInGame++;
        if (playerInGame == PhotonNetwork.PlayerList.Length)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefab, spawnPositions[0].position, Quaternion.identity);

        //forma larga
        //playerObj.GetComponent<PlayerController>().photonView.RPC("Init", RpcTarget.All, PhotonNetwork.LocalPlayer);

        //uso de variable para facil lectura
        PlayerControllerFSM playScript = playerObj.GetComponent<PlayerControllerFSM>();
        //playScript.photonView.RPC("Init", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }

}

