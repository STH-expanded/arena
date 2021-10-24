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
        //check health changes
    }
}
