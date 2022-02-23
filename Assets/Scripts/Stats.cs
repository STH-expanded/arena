using System.Collections;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
       maxHealthText.text = playerManager.unitStatisticsManager.unitStatistics.CurrentHealth.ToString() + "/" + playerManager.unitStatisticsManager.unitStatistics.Health.ToString();
       speedText.text = playerManager.unitStatisticsManager.unitStatistics.Speed.ToString();
       attackText.text = playerManager.unitStatisticsManager.unitStatistics.Attack.ToString();
       defenseText.text = playerManager.unitStatisticsManager.unitStatistics.Defense.ToString();
    }
}
