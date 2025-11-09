using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public int id;
    public string itemName;
    public float value;


    public void InitializeItem(string _name)
    {
        id = Random.Range(0, 100);
        itemName = _name;
        value = Random.Range(0f, 100f);
    }

    public string ReturnName()
    {
        return itemName;
    }

    public float ReturnValue()
    {
        return value;
    }
}
