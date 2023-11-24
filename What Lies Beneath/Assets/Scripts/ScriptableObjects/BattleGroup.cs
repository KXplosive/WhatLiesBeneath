using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Battle Groups", menuName = "Enemy Group")]
public class BattleGroup : ScriptableObject
{
    public new string name;
    public GameObject[] enemies;
}