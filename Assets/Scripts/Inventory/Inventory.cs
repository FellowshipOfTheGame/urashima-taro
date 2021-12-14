using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int spaces;

    [SerializeField] private List<ItemSO> items = new List<ItemSO>();

    // Find if a item is in the list of items and return it index in the list
    // if not, return -1
    private int IsInInventory(ItemSO item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (item.ID == items[i].ID)
                return i;
        }
        return -1;
    }
    private int IsInInventory(int itemID)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (itemID == items[i].ID)
                return i;
        }
        return -1;
    }

    // Update the quantity of the item adding the value 'quantityAdd'
    // Do almost the same of the function 'Add Inventory'
    public void UpdateItemQuantity(ItemSO item/*, int quantityAdd*/)
    {
        int quantityAdd = 1;
        int itemIdx = IsInInventory(item);
        
        // Test if the item is in the list of items
        if (itemIdx != -1)
        {
            int quantitySum = items[itemIdx].quantity + quantityAdd;

            if (quantitySum > 0)
                items[itemIdx].quantity = quantitySum;
            else
                items.Remove(item);            
        }
        else
        {
            if (quantityAdd > 0)
            {
                item.quantity = quantityAdd;
                items.Add(item);
            }
        }
    }

    public void AddInventory(ItemSO item)
    {
        if(items.Count == spaces)
        {
            Debug.Log("There's no space left!");
            return;
        }

        int itemIdx = IsInInventory(item);

        // Test if the item is already in the inventory
        if (itemIdx == -1) 
        {
            item.quantity += 1;
            items.Add(item);            
        } 
        else 
        {
            items[itemIdx].quantity += 1;
        }
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
