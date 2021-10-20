using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

public class CPUStatistics : MonoBehaviour
{
    public double Level = 1;
    private string Name;
    public double MaxHealth;
    public double CurrentHealth;
    public double Attack;
    public double Defense;
    public double Speed;

    public void Start()
    {
        Random random = new Random();

        double[] n =
        {
            0,
            Math.Round(random.NextDouble() * (this.Level - 0) + 0, 2),
            Math.Round(random.NextDouble() * (this.Level - 0) + 0, 2),
            Math.Round(random.NextDouble() * (this.Level - 0) + 0, 2),
            this.Level
        };

        Array.Sort(n);

        for (int i = 1; i < n.Length; i++)
        {
            double j = 0.1 + n[i] - n[i - 1];
            switch (i)
            {
                case 1:
                    this.MaxHealth = 80 * j + 20;
                    break;
                case 2:
                    this.Attack = 39 * j + 1;
                    break;
                case 3:
                    this.Defense = 20 * j;
                    break;
                case 4:
                    this.Speed = 6 * j + 6;
                    break;
            }
        }

        this.CurrentHealth = this.MaxHealth;
    }
}