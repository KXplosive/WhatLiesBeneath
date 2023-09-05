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

    public int maxHP;
    public int HP;

    public int maxMP;
    public int MP;

    public int ATK;
    public int DEF;
    public int stamina;
}
