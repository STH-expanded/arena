using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class CPUStatistics : MonoBehaviour
{
    public double Level = 0.5;
    private string Name;
    public double MaxHealth;
    public double CurrentHealth;
    public double Attack;
    public double Defense;
    public double Speed;
    
    public void Start()
    {
        Random random = new Random();         
        // Math.Round(random.NextDouble() * (this.Level - 0.01) + 0.01, 2); 
        double HealthWeight = 0;
        double AttackWeight = 0;
        double DefenseWeight = 0;
        double SpeedWeight = 0;

        double[] n =
        {
            0,
            Math.Round(random.NextDouble() * (this.Level - 0) + 0, 2),
            Math.Round(random.NextDouble() * (this.Level - 0) + 0, 2),
            Math.Round(random.NextDouble() * (this.Level - 0) + 0, 2),
            this.Level
        };
        
        Array.Sort(n);
        
        double[] stats =
        {
            HealthWeight, AttackWeight, DefenseWeight, SpeedWeight
        };

        for (int i = 1; i < n.Length; i++)
        {
            stats[i - 1] = n[i] - n[i - 1];
            Debug.Log(stats[i - 1]);
        }
        // 0, X, Y, Z, 0.5
    }

    public double GetHealth()
    {
        return 0;
    }

    public double GetAttack()
    {
        return 0;
    }
    
    public double GetDefense()
    {
        return 0;
    }
    
    public double GetSpeed()
    {
        return 0;
    }
}