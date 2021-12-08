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
        new Reward(0,"HP +1", applyRewardHP), 
        new Reward(1,"ATK +1",applyRewardATK), 
        new Reward(2,"SPD +1",applyRewardSPD),
        new Reward(3,"DEF +1",applyRewardDEF)
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
            int enemyLevel = Random.Range(level + i * 5, level + (i + 1) * 5);
            CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
            cardDisplay.reward = rewardAvailble[Random.Range(0, rewardAvailble.Length)];
            string opponentTitle = opponentTitles[Random.Range(0, opponentTitles.Length)];
            string opponentName = opponentNames[Random.Range(0, opponentNames.Length)];
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


    public static int applyRewardHP(GameObject player)
    {
        player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Health++;
        return  player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Health;
    }
    public static int applyRewardATK(GameObject player)
    {
        player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Attack++;
        return player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Attack;
    }
    public static int applyRewardSPD(GameObject player)
    {
        player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Speed++;
        return player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Speed;
    }
    public static int applyRewardDEF(GameObject player)
    {
        player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Defense++;
        return player.GetComponent<PlayerManager>().unitStatisticsManager.unitStatistics.Defense;
    }
}
