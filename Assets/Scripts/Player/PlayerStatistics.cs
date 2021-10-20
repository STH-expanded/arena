using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public float Attack;
    public float Defense;
    public float Speed;
    public HealthBar HealthBar;

    private void Start()
    {
        this.CurrentHealth = this.MaxHealth;
        HealthBar.setMaxHealth(this.MaxHealth);
        HealthBar.SetCurrentHealth(this.CurrentHealth);
    }
}
