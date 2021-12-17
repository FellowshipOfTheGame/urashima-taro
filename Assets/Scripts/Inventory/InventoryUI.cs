using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform gameObjectParent; 

    [SerializeField] private Inventory inventory;

    InventorySlot[] slots;

    // This update the inventory every frame, so maybe we could change the inventory only 
    // when an item is changed?
    void Update()
    {
        slots = gameObjectParent.GetComponentsInChildren<InventorySlot>();

        UpdateUI();
    }

    void UpdateUI()
    {
        List<ItemSO> listInventory = inventory.GetInventory();

        for(int i = 0; i < slots.Length; i++)
        {
            if(i < listInventory.Count)
            {
                slots[i].AddItem(listInventory[i]);
                slots[i].UpdateQuantity();
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
