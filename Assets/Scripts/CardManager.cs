using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;

    public bool isActive;

    public GameObject player;
    public GameObject enemy;



    private readonly string[] opponentTitles = {
        "Archonte", "Auguste", "Baron", "César", "Comte", "Duc", "Grand-duc", "Jarl", "Jinong", "Joupan", "Knèze", "Lord", "Magnat", "Margrave", "Marquis", "Nizam", "Padichah", "Prince consort", "Roi consort", "Tayiji", "Vice-roi", "Amiral", "Ban", "Baronnet", "Brigadier", "Burgrave", "Capitaine", "Colonel", "Commandeur", "Despote", "Général", "Gouverneur", "Lieutenant", "Magnat", "Maréchal", "Pacha", "Prince-évêque", "Stratège", "Topotérète", "Vicomte", "Vidame"
    };
    private readonly string[] opponentNames = {
        "Samy", "Henry", "Léo", "Maxime", "Hugo", "Erwan", "Mathis", "Alex", "Geoffrey", "Paul", "Adrien", "Mattéo", "Tanguy"
    };
    private readonly Reward[] rewardAvailble = {
        new Reward(0,"MaxHP +", applyRewardHP), 
        new Reward(1,"ATK +",applyRewardATK), 
        new Reward(2,"SPD +",applyRewardSPD),
        new Reward(3,"DEF +",applyRewardDEF),
        new Reward(4,"Heal",applyRewardHeal)
    };
    public void InitCards(int level)
    {

        Debug.Log("Init cards");
        card1.SetActive(true);
        card2.SetActive(true);
        card3.SetActive(true);
        isActive = true;
        player.SetActive(false);
        enemy.SetActive(false);

        GameObject[] cards = { card1, card2, card3 };
        int i = 0;
        foreach (GameObject card in cards)
        {
            int enemyLevel = UnityEngine.Random.Range(level + i * 5, level + (i + 1) * 5);
            CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
            cardDisplay.reward = rewardAvailble[UnityEngine.Random.Range(0, rewardAvailble.Length)];
            string opponentTitle = opponentTitles[UnityEngine.Random.Range(0, opponentTitles.Length)];
            string opponentName = opponentNames[UnityEngine.Random.Range(0, opponentNames.Length)];
            string opponentFullName = string.Format("{0} {1}", opponentTitle, opponentName);
            cardDisplay.setCardValues(enemyLevel, opponentFullName);
            i++;
        }


        gameObject.SetActive(true);
    }

    public void ResetUnits()
    {
        player.SetActive(true);
        player.GetComponent<PlayerManager>().ResetTransform();
        player.GetComponent<WeaponSlotManager>().CloseDamageCollider();

        enemy.SetActive(true);
        enemy.GetComponent<EnemyManager>().ResetTransform();
    }
  

    public static int applyRewardHP(PlayerManager playerManager)
    {
        // hp max 3-5
        int hpAdd = UnityEngine.Random.Range(3,5);
        playerManager.unitStatisticsManager.unitStatistics.Health+=hpAdd;
        playerManager.unitStatisticsManager.unitStatistics.CurrentHealth+=hpAdd;
        return playerManager.unitStatisticsManager.unitStatistics.Health;
    }
    public static int applyRewardATK(PlayerManager playerManager)
    {
        // atk 1-3
       playerManager.unitStatisticsManager.unitStatistics.Attack+=UnityEngine.Random.Range(1,3);
        return playerManager.unitStatisticsManager.unitStatistics.Attack;
    }
    public static int applyRewardSPD(PlayerManager playerManager)
    {
        // spd 1-3
       playerManager.unitStatisticsManager.unitStatistics.Speed+=UnityEngine.Random.Range(1,3);
        return playerManager.unitStatisticsManager.unitStatistics.Speed;
    }
    public static int applyRewardDEF(PlayerManager playerManager)
    {
        // def 1-3
       playerManager.unitStatisticsManager.unitStatistics.Defense+=UnityEngine.Random.Range(1,3);
        return playerManager.unitStatisticsManager.unitStatistics.Defense;
    }
     public static int applyRewardHeal(PlayerManager playerManager)
    {
        // Heal 40%-70%
        int maxHp = playerManager.unitStatisticsManager.unitStatistics.Health;
        float percentInt = UnityEngine.Random.Range(40,70);
        float percentHeal = percentInt / 100;
        playerManager.unitStatisticsManager.unitStatistics.CurrentHealth += (int) Math.Floor(maxHp*percentHeal);
        if (playerManager.unitStatisticsManager.unitStatistics.CurrentHealth > playerManager.unitStatisticsManager.unitStatistics.Health)
        {
            playerManager.unitStatisticsManager.unitStatistics.CurrentHealth = playerManager.unitStatisticsManager.unitStatistics.Health;
        }
        return playerManager.unitStatisticsManager.unitStatistics.CurrentHealth;
    }
}
