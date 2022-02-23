﻿using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public TextMeshPro levelText;
    [SerializeField] public TextMeshPro nameText;

    [SerializeField] public TextMeshPro healthText;
    [SerializeField] public TextMeshPro speedText;
    [SerializeField] public TextMeshPro attackText;
    [SerializeField] public TextMeshPro defenseText;
    [SerializeField] public TextMeshPro rewardText;

    public CardManager cardManager;
    public CameraHandle cameraHandle;
    
    public UserInterface userInterface;

    public UnitStatisticsManager unitStatisticsManager;
    public UnitStatisticsManager enemyStatsManager;
    public Stats statsManager;
    
    public Reward reward;
    public PlayerManager playerManager;

    private void Awake()
    {
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
    }

    void Start()
    {
        /*Button btn = selectButton.GetComponent<Button>();
        btn.onClick.AddListener(SelectAction);*/
    }

    public void SetCardValues(int level, string enemyName)
    {
        unitStatisticsManager.InitLevel(level);
        UnitStatistics stats = unitStatisticsManager.unitStatistics;

        levelText.text = $"LVL {level}";
        nameText.text = enemyName;
        healthText.text = stats.Health.ToString();
        attackText.text = stats.Attack.ToString();
        defenseText.text = stats.Defense.ToString();
        speedText.text = stats.Speed.ToString();
        // rewardText.text = reward.name;
    }

    private void SelectAction()
    {
        Debug.Log("Start fight");
        enemyStatsManager.InitStats(unitStatisticsManager.unitStatistics);
        cameraHandle.isIntro = true;
        userInterface.InitHealthBars();

        cardManager.isActive = false;
        statsManager.isActive = false;
        statsManager.statsCard.SetActive(false);
        playerManager.rewardGame = reward;

        cardManager.ResetUnits();
    }
}
