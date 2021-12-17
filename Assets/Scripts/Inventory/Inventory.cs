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
    }

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
