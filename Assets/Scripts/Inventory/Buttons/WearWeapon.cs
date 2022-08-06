using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearWeapon: MonoBehaviour
{
    private GameObject player;
    private static GameObject weaponPrefab;
    [HideInInspector] public ItemSO item;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void WearItem()
    {
        // Tests if the player already is holding a weapon
        if (weaponPrefab != null)
        {
            Destroy(weaponPrefab);
        }
        // Instantiate the prefab containing the weapon script
        weaponPrefab = Instantiate(item.itemPrefab, player.transform.position, Quaternion.identity);
        // Sets the prefab parent to be the player object
        weaponPrefab.transform.parent = player.transform;
    }
}