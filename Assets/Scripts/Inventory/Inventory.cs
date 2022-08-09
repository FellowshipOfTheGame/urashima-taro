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

    [SerializeField] private GameObject inventoryUI;

    [SerializeField] private GameObject[] otherUI;

    private ItemSO[] equippedItems = new ItemSO[4];
    // player
    private GameObject player;

    // gameobject vazio onde estao os weapon slots
    private Transform weaponPlayer;
    // referencia aos weapon slots no player
    private Transform[] weaponSlots = new Transform[4];

    private bool inventarioAtivo = false;

    ItemSO currentItem;

    private static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Mais de 1 Inventario");
        }
        instance = this;
    }

    private void Start()
    {
        player = GameObject.Find("Jogador 1");
        weaponPlayer = player.transform.Find("Armas");

        for(int i = 0; i<weaponPlayer.childCount; i++)
        {
            weaponSlots[i] = weaponPlayer.GetChild(i);
        }
    }

    public static Inventory GetInstance()
    {
        return instance;
    }

    private void Update()
    {
        if (InputManager.GetInstance().GetInventario())
        {
            if (!inventarioAtivo)
            {
                OpenInventory();
            }
            else
            {
                // FIXME: como estou mudando o action map, o tab n funciona para fechar o inventario
                // provavelmente tem uma maneira de fazer isso sem adicionar (mais) um comando ao action map,
                // mas por enquanto so vou deixar com um botao
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        InputManager.GetInstance().ChangeActionMap("Dialogo");

        Time.timeScale = 0;

        // a arma n consegue acessar a UI do jogador se estiver desativada
        // a UI do inventario vai se sobrepor a UI do jogador ate eu achar uma solucao melhor

        /*foreach (GameObject ui in otherUI)
        {
            ui.SetActive(false);
        }*/

        inventoryUI.SetActive(true);

        inventarioAtivo = true;
    }

    public void CloseInventory()
    {
        InputManager.GetInstance().ChangeActionMap("Player_Base");

        inventarioAtivo = false;

        inventoryUI.SetActive(false);

        foreach (GameObject ui in otherUI)
        {
            ui.SetActive(true);
        }

        Time.timeScale = 1;
    }

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
    }
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

    // Update the quaugntity of the item adding the value 'quantityAdd'
    // Do almost the same of the function 'Add Inventory'
    public void UpdateItemQuantity(ItemSO item, int quantityAdd)
    {
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
        Debug.Log(item.quantity);
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
            items.Add(item);            
        } 
        else 
        {
            items[itemIdx].quantity += item.quantity;
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
