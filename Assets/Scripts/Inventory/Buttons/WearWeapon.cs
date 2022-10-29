using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WearWeapon: MonoBehaviour
{
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _bulletNumber;

    private GameObject player;
    private static GameObject weaponPrefab;
    [HideInInspector] public ItemSO item;

    private WeaponBadge _weaponBadge;

    private void Start()
    {
        _weaponBadge = WeaponBadge.Instance;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void WearItem()
    {
        // Tests if the player already is holding a weapon
        if (weaponPrefab != null)
        {
            Destroy(weaponPrefab);
        }

        _weaponBadge.currentWeapon = item;        
        _weaponBadge.AddWeaponBadge();

        // Instantiate the prefab containing the weapon script
        weaponPrefab = Instantiate(item.itemPrefab, player.transform.position, Quaternion.identity);
        // Sets the prefab parent to be the player object
        weaponPrefab.transform.parent = player.transform;
    }
}