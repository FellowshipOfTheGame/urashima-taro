using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int spaces;

    [SerializeField] private List<ItemSO> items = new List<ItemSO>();

    [SerializeField] private GameObject optionsItem;

    [SerializeField] private RectTransform canvas;

    [SerializeField] private RectTransform panel;

    ItemSO currentItem;

    public void InteractItem()
    {
        // gambiarra 1:
        // Verifica se o inventory slot ta mostrando uma imagem
        GameObject button = EventSystem.current.currentSelectedGameObject;
        Image image = button.GetComponentInChildren<Image>();

        if (image == null || !image.IsActive())
        {
            Debug.Log("Sem item");
            return;
        }

        optionsItem.SetActive(true);
        optionsItem.transform.position = button.transform.position;

        // gambiarra 2: o inimigo agora eh outro
        // Como cada parent tem o nome SlotGFX (i), dei split nessa string e peguei o i
        string[] indexC = button.transform.parent.name.Split(new char[] { '(', ')' });
        int index = int.Parse(indexC[1]) - 1;

        // salva o item (modificar caso necessario)
        currentItem = items[index];

        Debug.Log("item equipado: " + items[index].name + " index: " + index);
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
