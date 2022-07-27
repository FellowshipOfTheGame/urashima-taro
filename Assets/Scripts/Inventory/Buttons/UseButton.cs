using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseButton : MonoBehaviour
{
    private Inventory inventory;
    public ItemSO item;

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
