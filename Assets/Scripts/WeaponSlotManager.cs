using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    WeaponHolderSlot handSlot;
    public WeaponItem weaponItem;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            handSlot = weaponSlot;
        }
    }

    private void Start()
    {
        LoadWeaponSlot(weaponItem);
    }

    public void LoadWeaponSlot(WeaponItem weaponItem)
    {
        handSlot.LoadWeaponModel(weaponItem);
    }
}
