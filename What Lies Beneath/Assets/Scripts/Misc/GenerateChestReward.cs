using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenerateChestReward : MonoBehaviour
{
    /*
     * Chest Loot Table:
     * 80% chance of getting just gold
     * Infernal Amulet
     * Religious Amulet
     * Moss
     * Solomon Log
     * Holy Skull
     */

    public Item[] lootTable;

    public PlayerControllerFSM player;

    public TMP_Text message;

    int gold;

    
    Item generateItem()
    {
        List<Item> it = new List<Item>();
        foreach(Item i in lootTable)
        {
            for(int x = 0; x < 6 - i.rarity; x++)
            {
                it.Add(i);
            }
        }
        int ranInt = Random.Range(0, it.Count);
        Debug.Log(it[ranInt].name);
        return it[ranInt];
    }
    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);
        int rng = Random.Range(1, 11);
        Debug.Log(rng);
        if (rng >= 5)
        {
            //generate item
            Item newItem = generateItem();
            //player.items.Add(newItem);
            //get gold
            player.inventory.addItem(newItem);
            gold = Random.Range(75, 151);
            message.SetText("Obtained " + newItem.name + " and " + gold.ToString() + " gold!");
        }
        else
        {
            //get gold
            gold = Random.Range(200, 301);
            message.SetText("Obtained " + gold.ToString() + " gold!");
        }
        message.gameObject.SetActive(true);
        Debug.Log(gold);
        player.gold += gold;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
