using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public List<GameObject> items;
    public List<Item> itemList;
    
    private void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            int itemLvl = items[i].GetComponent<Projectile>().GetLevel();
            itemList.Add(new Item(items[i], itemLvl));
        }
    }
}

public class Item 
{
    public GameObject item;
    public int itemLvl;

    public Item(GameObject newItem, int newLvl)
    {
        item = newItem;
        itemLvl = newLvl;
    }
}

