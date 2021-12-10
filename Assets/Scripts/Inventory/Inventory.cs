using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int spaces;

    [SerializeField] private List<ItemSO> items = new List<ItemSO>();

    public void AddInventory(ItemSO item)
    {
        if(items.Count == spaces)
        {
            Debug.Log("There's no space left!");
            return;
        }

        items.Add(item);
    }

    public void RemoveInventory(ItemSO item)
    {
        if(items.Count == 0)
        {
            Debug.Log("There's no items in inventory!");
            return;
        }

        items.Remove(item);
    }

    public List<ItemSO> GetInventory()
    {
        return items;
    }
}
