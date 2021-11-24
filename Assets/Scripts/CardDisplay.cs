﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public Text levelText;
    [SerializeField] public Text nameText;
    [SerializeField] public Image artwork;

    [SerializeField] public Text healthText;
    [SerializeField] public Text speedText;
    [SerializeField] public Text attackText;
    [SerializeField] public Text defenseText;

    public CardManager cardManager;

    public Slider healthSlider;
    public Slider speedSlider;
    public Slider attackSlider;
    public Slider defenseSlider;

    public UnitStatisticsManager unitStatisticsManager;
    public UnitStatisticsManager enemyStatsManager;

    public Button selectButton;

    private void Awake()
    {
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
    }

    void Start()
    {
        Button btn = selectButton.GetComponent<Button>();
        btn.onClick.AddListener(SelectAction);
    }

    public void setCardValues(int level, string enemyName)
    {
        unitStatisticsManager.InitLevel(level);
        UnitStatistics stats = unitStatisticsManager.unitStatistics;

        levelText.text = string.Format("Level {0}", level);
        nameText.text = enemyName;

        healthSlider.value = stats.Health;
        healthText.text = stats.Health.ToString();

        attackSlider.value = stats.Attack;
        attackText.text = stats.Attack.ToString();

        defenseSlider.value = stats.Defense;
        defenseText.text = stats.Defense.ToString();

        speedSlider.value = stats.Speed;
        speedText.text = stats.Speed.ToString();
    }

    void SelectAction()
    {
        Debug.Log("Start fight");

        enemyStatsManager.InitStats(unitStatisticsManager.unitStatistics);
        cardManager.isActive = false;

        cardManager.ResetUnits();
    }
}
