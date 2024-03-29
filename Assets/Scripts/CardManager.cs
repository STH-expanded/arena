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

    public GameObject card1Light;
    public GameObject card2Light;
    public GameObject card3Light;
    public GameObject mainSceneLight;

    public bool isActive;
    public float prevSpeed;
    
    public GameObject player;
    public GameObject enemy;

    private readonly string[] _opponentTitles = {
        "Archonte", "Auguste", "Baron", "César", "Comte", "Duc", "Grand-duc", "Jarl", "Jinong", "Joupan", "Knèze", "Lord", 
        "Magnat", "Margrave", "Marquis", "Nizam", "Padichah", "Prince consort", "Roi consort", "Tayiji", "Vice-roi", "Amiral", 
        "Ban", "Baronnet", "Brigadier", "Burgrave", "Capitaine", "Colonel", "Commandeur", "Despote", "Général", "Gouverneur", 
        "Lieutenant", "Magnat", "Maréchal", "Pacha", "Stratège", "Topotérète", "Vicomte", "Vidame"
    };
    private readonly string[] _opponentNames = {
        "Samy", "Henry", "Léo", "Maxime", "Hugo", "Erwan", "Mathis", "Alex", "Geoffrey", "Paul", "Adrien", "Mattéo", "Tanguy"
    };
    private readonly Reward[] _rewardAvailable = {
        new Reward(0,"MaxHP +", "heartUp", ApplyRewardHp), 
        new Reward(1,"ATK +", "swordUp", ApplyRewardAtk), 
        new Reward(2,"SPD +", "speedUp", ApplyRewardSpeed),
        new Reward(3,"DEF +", "shieldUp", ApplyRewardDef),
        new Reward(4,"Heal", "potion", ApplyRewardHeal)
    };
    
    public void InitCards(int level)
    {
        Debug.Log("Init cards");
        mainSceneLight.SetActive(false);
        card1.SetActive(true);
        card2.SetActive(true);
        card3.SetActive(true);
        isActive = true;
        player.SetActive(false);
        enemy.SetActive(false);

        GameObject[] cards = { card1, card2, card3 };
        var i = 0;
        foreach (var card in cards)
        {
            var enemyLevel = UnityEngine.Random.Range(level + i * 5, level + (i + 1) * 5);
            var cardDisplay = card.GetComponent<CardDisplay>();
            cardDisplay.reward = _rewardAvailable[UnityEngine.Random.Range(0, _rewardAvailable.Length)];
            var opponentTitle = _opponentTitles[UnityEngine.Random.Range(0, _opponentTitles.Length)];
            var opponentName = _opponentNames[UnityEngine.Random.Range(0, _opponentNames.Length)];
            var opponentFullName = $"{opponentTitle} {opponentName}";
            cardDisplay.SetCardValues(enemyLevel, opponentFullName);
            i++;
        }
        
        GameObject[] cardsLights = { card1Light, card2Light, card3Light };
        foreach (var cardLight in cardsLights)
        {
            cardLight.SetActive(true);
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
  

    private static int ApplyRewardHp(PlayerManager playerManager)
    {
        // hp max 3-5
        var hpAdd = UnityEngine.Random.Range(3,5);
        playerManager.unitStatisticsManager.unitStatistics.Health += hpAdd;
        playerManager.unitStatisticsManager.unitStatistics.CurrentHealth += hpAdd;
        return playerManager.unitStatisticsManager.unitStatistics.Health;
    }
    private static int ApplyRewardAtk(PlayerManager playerManager)
    {
        // atc 1-3
        playerManager.unitStatisticsManager.unitStatistics.Attack += UnityEngine.Random.Range(1, 3);
        return playerManager.unitStatisticsManager.unitStatistics.Attack;
    }
    private static int ApplyRewardSpeed(PlayerManager playerManager)
    {
        // spd 1-3
        playerManager.unitStatisticsManager.unitStatistics.Speed += UnityEngine.Random.Range(1, 3);
        return playerManager.unitStatisticsManager.unitStatistics.Speed;
    }
    private static int ApplyRewardDef(PlayerManager playerManager)
    {
        // def 1-3
        playerManager.unitStatisticsManager.unitStatistics.Defense += UnityEngine.Random.Range(1, 3);
        return playerManager.unitStatisticsManager.unitStatistics.Defense;
    }
     private static int ApplyRewardHeal(PlayerManager playerManager)
    {
        // Heal 40%-70%
        const int healMinReward = 40;
        const int healMaxReward = 70;
        var maxHp = playerManager.unitStatisticsManager.unitStatistics.Health;
        float percentInt = UnityEngine.Random.Range(healMinReward, healMaxReward);
        var percentHeal = percentInt / 100;
        
        playerManager.unitStatisticsManager.unitStatistics.CurrentHealth += (int) Math.Floor(maxHp * percentHeal);
        if (playerManager.unitStatisticsManager.unitStatistics.CurrentHealth > playerManager.unitStatisticsManager.unitStatistics.Health)
        {
            playerManager.unitStatisticsManager.unitStatistics.CurrentHealth = playerManager.unitStatisticsManager.unitStatistics.Health;
        }
        return playerManager.unitStatisticsManager.unitStatistics.CurrentHealth;
    }
}
