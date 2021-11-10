using System;

[Serializable]
public class UnitStatistics
{
    public int Level { get; set; } = 1;

    public int Health { get; set; } = 20;
    public float HealthGrowth { get; set; }  = 0.5f;
    public int CurrentHealth { get; set; }

    public int Attack { get; set; } = 4;
    public float AttackGrowth { get; set; } = 0.25f;

    public int Defense { get; set; } = 4;
    public float DefenseGrowth { get; set; } = 0.1f;

    public int Speed { get; set; } = 6;
    public float SpeedGrowth { get; set; } = 0.2f;
}