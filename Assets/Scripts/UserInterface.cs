using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    public Slider playerHealthBar;
    public PlayerManager playerManager;

    public Slider enemyHealthBar;
    public EnemyManager enemyManager;

    public void InitHealthBars()
    {
        playerHealthBar.maxValue = playerManager.unitStatisticsManager.unitStatistics.Health;
        playerHealthBar.value = playerManager.unitStatisticsManager.unitStatistics.Health;

        enemyHealthBar.maxValue = enemyManager.unitStatisticsManager.unitStatistics.Health;
        enemyHealthBar.value = enemyManager.unitStatisticsManager.unitStatistics.Health;
    }

    void Update()
    {
        if (playerManager.unitStatisticsManager.unitStatistics.CurrentHealth != playerHealthBar.value)
        {
            playerHealthBar.value = Mathf.Lerp(playerHealthBar.value, playerManager.unitStatisticsManager.unitStatistics.CurrentHealth, 0.05f);
        }

        if (enemyManager.unitStatisticsManager.unitStatistics.CurrentHealth != enemyHealthBar.value)
        {
            enemyHealthBar.value = Mathf.Lerp(enemyHealthBar.value, enemyManager.unitStatisticsManager.unitStatistics.CurrentHealth, 0.05f);
        }
    }
}
