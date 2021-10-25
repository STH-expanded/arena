using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[Serializable]
public class UnitStatistics
{
    private int level = 1;

    private int health = 20;
    private int currentHealth;
    private float healthGrowth = 0.5f;

    private int attack = 4;
    private float attackGrowth = 0.25f;

    private int defense = 4;
    private float defenseGrowth = 0.1f;

    private int speed = 6;
    private float speedGrowth = 0.2f;

    public int Level { get => level; set => level = value; }
    public int Health { get => health; set => health = value; }
    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float HealthGrowth { get => healthGrowth; set => healthGrowth = value; }
    public int Attack { get => attack; set => attack = value; }
    public float AttackGrowth { get => attackGrowth; set => attackGrowth = value; }
    public int Defense { get => defense; set => defense = value; }
    public float DefenseGrowth { get => defenseGrowth; set => defenseGrowth = value; }
    public int Speed { get => speed; set => speed = value; }
    public float SpeedGrowth { get => speedGrowth; set => speedGrowth = value; }

    public UnitStatistics(int baseLevel)
    {
        while (Level < baseLevel) LevelUp();
        currentHealth = health;
    }

    public void LevelUp()
    {
        if (HealthGrowth > Random.Range(0.0f, 1.0f)) Health++;
        if (AttackGrowth > Random.Range(0.0f, 1.0f)) Attack++;
        if (DefenseGrowth > Random.Range(0.0f, 1.0f)) Defense++;
        if (SpeedGrowth > Random.Range(0.0f, 1.0f)) Speed++;
        Level++;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManager.LoadScene("MainMenu");
        }
    }
}