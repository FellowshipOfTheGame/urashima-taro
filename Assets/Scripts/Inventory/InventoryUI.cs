using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform gameObjectParent; 

    [SerializeField] private Inventory inventory;

    [SerializeField] private GameObject inventoryMenu;

    InventorySlot[] slots;

    // This update the inventory every frame (when the inventory menu is active)
    
    void Update()
    {
        if (inventoryMenu.activeSelf == true)
        {
            slots = gameObjectParent.GetComponentsInChildren<InventorySlot>();
            UpdateUI();
        }
    }
    
    void UpdateUI()
    {
        slots = gameObjectParent.GetComponentsInChildren<InventorySlot>();

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
