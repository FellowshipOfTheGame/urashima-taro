using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearWeapon: MonoBehaviour
{
    private Inventory inventory;
    private GameObject player;
    [HideInInspector] public ItemSO item;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void WearItem()
    {
        // Temporarily only works to the pistol item
        GameObject.FindWithTag("Player").GetComponent<Tiro>().enabled = true;
    }
}