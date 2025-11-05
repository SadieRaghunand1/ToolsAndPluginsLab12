using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> items;
    [SerializeField] List<string> possibleNames;

    private void Start()
    {
        InitializeInventory();
        LinearSearchByName("Bob");
    }

    void InitializeInventory()
    {
        items = new List<InventoryItem>();  

        int _size = Random.Range(3, 20);
        for (int i = 0; i < _size; i++)
        {
            //Create item
            InventoryItem _newItem = new InventoryItem();

            //Randomize name
            int _i = Random.Range(0, possibleNames.Count);
            string _name = possibleNames[_i];
            possibleNames.RemoveAt(_i);

            _newItem.InitializeItem(_name);
            items.Add(_newItem);
        }

    }

    InventoryItem LinearSearchByName(string itemName)
    {
        InventoryItem _itemFound = null;

        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].ReturnName() == itemName)
            {
                _itemFound = items[i];
                Debug.Log(_itemFound);
                return _itemFound;
            }
        }
        Debug.Log("No item found");
        return null;
    }
}
