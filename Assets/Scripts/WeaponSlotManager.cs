using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{
    DamageCollider damageCollider;

    private void Start()
    {
        LoadWeaponSlot();
    }

    public void LoadWeaponSlot()
    {
        LoadWeaponDamageCollider();
    }

    private void LoadWeaponDamageCollider()
    {
        damageCollider = GetComponentInChildren<DamageCollider>();
    }

    public void OpenDamageCollider()
    {
        damageCollider.EnableDamageCollider();
    }

    public void CloseDamageCollider()
    {
        damageCollider.DisableDamageCollider();
    }
}
