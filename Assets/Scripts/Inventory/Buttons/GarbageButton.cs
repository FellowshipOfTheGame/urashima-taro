using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageButton : MonoBehaviour
{
    private Inventory inventory;
    public ItemSO item;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    // Start is called before the first frame update
    public void RemoveItem()
    {
        inventory.RemoveInventory(item);
    }
}
