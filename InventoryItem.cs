using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    int id;
    string itemName;
    float value;


    public void InitializeItem(string _name)
    {
        id = Random.Range(0, 100);
        itemName = _name;
        value = Random.Range(0, 100);
    }

    public string ReturnName()
    {
        return itemName;
    }
}
