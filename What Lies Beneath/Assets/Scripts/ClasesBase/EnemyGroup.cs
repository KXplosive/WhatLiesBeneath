using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyGroup : MonoBehaviour
{
    public string GroupName;

    public enum groupType
    {
        COMBATE,
        HORDA,
        ELITE
    }
    public groupType Type;

    public GameObject[] enemies;
}
