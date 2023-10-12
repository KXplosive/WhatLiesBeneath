using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PersonajeBase
{
    public string nombre;

    public int level;

    public float baseHP;
    public float currentHP;

    public float baseMP;
    public float currentMP;

    public float baseST;
    public float currentST;

    public float temperature;

    public float attack;
    public float currentAttack;
    public float defense;
    public float currentDefense;

    public Attack[] attacks;
}
