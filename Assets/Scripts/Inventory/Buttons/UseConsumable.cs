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
        //diminui quantidade
        inventory.UpdateItemQuantity(item, -item.quantityRedusedByUse);
        // item.quantity -= item.quantityRedusedByUse;

        //aumenta vida
        Vida vida = GameObject.FindWithTag("Player").GetComponent<Vida>();
        vida.RecuperaVida(item.lifeHealed);
    }
}
