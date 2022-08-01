using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearWeapon: MonoBehaviour
{
    private Inventory inventory;
    [HideInInspector] public ItemSO item;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void WearItem()
    {
        Vida vida = GameObject.FindWithTag("Player").GetComponent<Vida>();
        vida.SetVidaExtra(item.lifeArmor);
    }
}