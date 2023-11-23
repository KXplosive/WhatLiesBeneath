using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInput;
    public GameObject Loading;
    public GameObject Connect;

    public void OnClickConnect()
    {
        if (usernameInput.text.Length > 0)
        {
            PhotonNetwork.NickName = usernameInput.text;
            Connect.SetActive(false);
            Loading.SetActive(true);
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }
}
