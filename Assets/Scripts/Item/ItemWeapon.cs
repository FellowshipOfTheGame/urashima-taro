using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class ItemWeapon : ItemSO
{
    void Awake()
    {
        this.name = "New Weapon";
        this.type = ItemType.Weapon;
    }
}
