using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using TMPro;
using System;

public class WeaponAmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text WeaponNameText;
    [SerializeField] private TMP_Text CurrentBulletText;
    [SerializeField] private TMP_Text TotalBulletText;

    private WeaponComponent WeaponComponent;

    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnWeaponEquipped(WeaponComponent weaponComponent)
    {
        WeaponComponent = weaponComponent;
    }

    private void OnDisable()
    {
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
    }

    private void Update()
    {
        if (!WeaponComponent) return;

        WeaponNameText.text = WeaponComponent.WeaponInformation.WeaponName;
        CurrentBulletText.text = WeaponComponent.WeaponInformation.BulletsInClip.ToString();
        TotalBulletText.text = WeaponComponent.WeaponInformation.BulletsAvailable.ToString();
    }
}
