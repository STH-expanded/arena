using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;

    public bool isActive;

    public GameObject player;
    public GameObject enemy;

    public void InitCards(int level)
    {
        Debug.Log("Init cards");
        isActive = true;
        player.SetActive(false);
        enemy.SetActive(false);

        GameObject[] cards = { card1, card2, card3 };
        int i = 0;
        foreach (GameObject card in cards)
        {
            int enemyLevel = Random.Range(level + i * 5, level + (i + 1) * 5);
            CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
            cardDisplay.setCardValues(enemyLevel);
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
}
