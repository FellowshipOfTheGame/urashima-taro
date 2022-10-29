using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WeaponBadge : MonoBehaviour
{
    [HideInInspector] public ItemSO currentWeapon;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private TextMeshProUGUI _bulletNumber;
    public static WeaponBadge Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void AddWeaponBadge()
    {
        _weaponImage.enabled = true;
        _bulletNumber.enabled = true;
        // Changes the WeaponBadge's icon and bullet number
        _weaponImage.sprite = currentWeapon.icon;
        _bulletNumber.text = currentWeapon.quantity.ToString();
    }

    public void RemoveWeaponBadge()
    {
        _weaponImage.enabled = false;
        _bulletNumber.enabled = false;

        if (currentWeapon != null)
            Destroy(currentWeapon);
    }
}
