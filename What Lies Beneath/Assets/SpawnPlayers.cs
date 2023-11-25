using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public GameObject playerPhoton;
    public Transform[] spawnPositions;
    public int spawnCount = 0;

    void Start()
    {
        PhotonNetwork.Instantiate("Player", spawnPositions[spawnCount].position, Quaternion.identity);
        spawnCount++;
    }

}

