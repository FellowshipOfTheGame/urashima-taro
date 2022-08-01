using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseConsumable : MonoBehaviour
{
    private Inventory inventory;
    [HideInInspector] public ItemSO item;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Start is called before the first frame update
    public void UseItem()
    {
        inventory.UpdateItemQuantity(item, -item.quantityRedusedByUse);
    }
}
