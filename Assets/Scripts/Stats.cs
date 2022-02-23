using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject statsCard;
    [SerializeField] public Text maxHealthText;
    [SerializeField] public Text speedText;
    [SerializeField] public Text attackText;
    [SerializeField] public Text defenseText;

    public bool isActive;

    public void InitStats(PlayerManager playerManager)
    {
        statsCard.SetActive(true);
       maxHealthText.text = "HP: " + playerManager.unitStatisticsManager.unitStatistics.CurrentHealth.ToString() + "/" + playerManager.unitStatisticsManager.unitStatistics.Health.ToString();
       speedText.text = "SPD: " + playerManager.unitStatisticsManager.unitStatistics.Speed.ToString();
       attackText.text = "ATT: " + playerManager.unitStatisticsManager.unitStatistics.Attack.ToString();
       defenseText.text = "DEF: " + playerManager.unitStatisticsManager.unitStatistics.Defense.ToString();
    }
}
