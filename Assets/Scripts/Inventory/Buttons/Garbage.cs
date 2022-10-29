using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    private Inventory inventory;
    [HideInInspector] public ItemSO item;

    private WeaponBadge _weaponBadge;

    private void Start()
    {
        _weaponBadge = WeaponBadge.Instance;

        inventory = FindObjectOfType<Inventory>();
    }

    // Start is called before the first frame update
    public void RemoveItem()
    {
        // Remove the icon and text in the WeaponBadge
        if (_weaponBadge.currentWeapon != null && _weaponBadge.currentWeapon.ID == item.ID)
            _weaponBadge.RemoveWeaponBadge();

        inventory.RemoveInventory(item);
    }
}
