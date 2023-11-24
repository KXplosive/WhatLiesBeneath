using System.Collections;
using System.Collections.Generic;
using System.Linq;
// using System.Threading;
// using TMPro;
// using Unity.Mathematics;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MonsterController : MonoBehaviourPunCallbacks
{

    [SerializeField] public List<GameObject> m;

    public bool coroutineOff;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject monster in monsters)
        {
            m.Add(monster);
        }
        coroutineOff = true;
    }

    [PunRPC]
    // Update is called once per frame
    void Update()
    {
        if (coroutineOff)
        {
            photonView.RPC("atkTimer", RpcTarget.All);
            coroutineOff = false;
        }
    }

    [PunRPC]
    IEnumerator atkTimer()
    {
        float randTime = Random.Range(4f, 8f);
        int randMon = Random.Range(0, m.Count);
        
        yield return new WaitForSeconds(randTime);
        MonsterB mon = m[randMon].GetComponent<MonsterB>();
        GameObject[] attackPlayer = GameObject.FindGameObjectsWithTag("Player");
        
        int whichPlayer = Random.Range(0, attackPlayer.Length);
        StartCoroutine(mon.Attacking(attackPlayer[whichPlayer]));
        yield return new WaitForSeconds(0.5f);
        coroutineOff = true;
        yield return null;
    }
}
