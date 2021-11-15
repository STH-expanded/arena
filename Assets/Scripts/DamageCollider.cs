using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;

    public int currentWeaponDamage = 25;

    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false;
    }

    public void EnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void DisableDamageCollider()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UnitStatisticsManager unitStatisticsManager = other.GetComponent<PlayerManager>().unitStatisticsManager;

            if (unitStatisticsManager != null)
            {
                unitStatisticsManager.TakeDamage(currentWeaponDamage);
            }
        }

        if (other.tag == "Enemy")
        {
            UnitStatisticsManager unitStatisticsManager = other.GetComponent<EnemyManager>().unitStatisticsManager;

            if (unitStatisticsManager != null)
            {
                unitStatisticsManager.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
