using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item",menuName = "Base Item")]
public class Item : ScriptableObject
{
    public new string name;
    public string description;
    public int rarity;
    public Sprite sprite;
}
