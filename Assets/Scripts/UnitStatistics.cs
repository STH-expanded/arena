using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class UnitStatistics
{
    public int Level = 1;

    public int Health = 20;
    public float HealthGrowth = 0.5f;

    public int Attack = 4;
    public float AttackGrowth = 0.25f;

    public int Defense = 4;
    public float DefenseGrowth = 0.1f;

    public int Speed = 6;
    public float SpeedGrowth = 0.2f;

    public UnitStatistics(int baseLevel)
    {
        while (Level < baseLevel) LevelUp();
    }

    public void LevelUp()
    {
        if (HealthGrowth > Random.Range(0.0f, 1.0f)) Health++;
        if (AttackGrowth > Random.Range(0.0f, 1.0f)) Attack++;
        if (DefenseGrowth > Random.Range(0.0f, 1.0f)) Defense++;
        if (SpeedGrowth > Random.Range(0.0f, 1.0f)) Speed++;
        Level++;
    }
}