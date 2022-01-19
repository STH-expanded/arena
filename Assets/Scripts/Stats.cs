using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Stats : MonoBehaviour
{
    [SerializeField] public Text maxHealthText;
    [SerializeField] public Text speedText;
    [SerializeField] public Text attackText;
    [SerializeField] public Text defenseText;
    
    public void InitStats(PlayerManager playerManager)
    {
       maxHealthText.text = "HP: " + playerManager.unitStatisticsManager.unitStatistics.CurrentHealth.ToString() + "/" + playerManager.unitStatisticsManager.unitStatistics.Health.ToString();
       speedText.text = "SPD: " + playerManager.unitStatisticsManager.unitStatistics.Speed.ToString();
       attackText.text = "ATT: " + playerManager.unitStatisticsManager.unitStatistics.Attack.ToString();
       defenseText.text = "DEF: " + playerManager.unitStatisticsManager.unitStatistics.Defense.ToString();
    }
}
