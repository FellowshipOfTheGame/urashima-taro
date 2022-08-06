using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearArmor : MonoBehaviour
{
    private Inventory inventory;
    [HideInInspector] public ItemSO item;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void WearItem()
    {
        //diminui quantidade
        inventory.UpdateItemQuantity(item, -item.quantityRedusedByUse);

        //coloca armadura
        Vida vida = GameObject.FindWithTag("Player").GetComponent<Vida>();
        vida.SetVidaExtra(item.lifeArmor);
    }
}
