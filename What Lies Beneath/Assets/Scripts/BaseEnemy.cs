using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseEnemy {
    public enum Type {
        REGULAR,
        RARE,
        ELITE,
        BOSS
    }

    public string name;

    public float maxHP;
    public float HP;

    public float maxMP;
    public float MP;

    public float ATK;
    public float DEF;
    public int stamina;
}
