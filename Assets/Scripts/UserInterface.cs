using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider healthBar;
    public PlayerManager playerManager;

    void Start()
    {
        healthBar.maxValue = playerManager.stats.Health;
        healthBar.value = playerManager.stats.Health;
    }

    void Update()
    {
        if (playerManager.stats.CurrentHealth != healthBar.value)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, playerManager.stats.CurrentHealth, 0.05f);
        }
    }
}
