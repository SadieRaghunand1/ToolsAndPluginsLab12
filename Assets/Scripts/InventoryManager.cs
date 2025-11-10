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
        QuickSortByValue();
        LinearSearchByName("Kerri");

        //binary
        SortByID();
        BinarySearchByID(50);
    }

    void InitializeInventory()
    {
        items = new List<InventoryItem>();

        List<string> availableNames = new List<string>(possibleNames); 

        int _size = Random.Range(3, Mathf.Min(20, availableNames.Count));
        for (int i = 0; i < _size; i++)
        {
            //Create item
            InventoryItem _newItem = new InventoryItem();

            //Randomize name
            int _i = Random.Range(0, availableNames.Count);
            string _name = availableNames[_i];
            availableNames.RemoveAt(_i); // added

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
                Debug.Log(itemName);
                return _itemFound;
            }
        }
        Debug.Log("No item found");
        return null;
    }

    //sorts the items value in descending order by item value
    public void QuickSortByValue()
    {
        if (items == null || items.Count <= 1)
            return;

        QuickSort(0, items.Count - 1);

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log($"[{i}] {items[i].value} - {items[i].itemName}");
        }
    }

    public void QuickSort(int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(low, high);
            QuickSort(low, pivot - 1);
            QuickSort(pivot + 1, high);
        }
    }

    public int Partition(int low, int high)
    {
        float pivot = items[high].ReturnValue();
        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (items[j].ReturnValue() >= pivot)
            {
                i++;

                InventoryItem temporary = items[i];
                items[i] = items[j];
                items[j] = temporary;

            }
        }
        InventoryItem temporaryNext = items[i + 1];
        items[i + 1] = items[high];
        items[high] = temporaryNext;

        return i + 1;
    }

    public void SortByID()
    {
        items.Sort((a, b) => a.id.CompareTo(b.id));
        Debug.Log("sorted by ID");
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log($"[{i}] ID: {items[i].id}, Name: {items[i].itemName}, Value: {items[i].value}");
        }
    }

    public InventoryItem BinarySearchByID(int targetID)
    {
        int low = 0;
        int high = items.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int currentID = items[mid].id;

            if (currentID == targetID)
            {
                Debug.Log($"Item found! ID: {currentID}, Name: {items[mid].itemName}, Value: {items[mid].value}");
                return items[mid];
            }
            else if (currentID < targetID)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        Debug.Log("No item found with that ID");
        return null;
    } 
}
