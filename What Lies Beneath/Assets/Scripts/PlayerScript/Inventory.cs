using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> items = new List<Item>();

    public void addItem(Item item)
    {
        items.Add(item);
    }

    public void useEffects()
    {
        foreach(Item item in items)
        {
            Debug.Log(item.description);
        }
    }

    public bool isItemInInventory(Item item)
    {
        return items.Contains(item);
    }

    public int getSize()
    {
        return items.Count;
    }
}
