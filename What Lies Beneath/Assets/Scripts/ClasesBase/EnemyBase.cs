using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBase
{
    public string nombre;

    public float currentHP;
    public float baseHP;
    public float stamina = 100 - (5*Variables.contNivel); // tiempo de atb
    public float Attack;
    public float currentAttack;
    public float Defense;
    public float currentDefense;
}
