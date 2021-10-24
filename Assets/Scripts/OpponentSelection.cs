using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpponentSelection : MonoBehaviour
{
    public int playerRank = 1;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;

    void Start()
    {
        GameObject[] cards = { card1, card2, card3 };
        int i = 0;
        foreach (GameObject card in cards)
        {
            int level = Random.Range(playerRank + i * 5, playerRank + (i + 1) * 5);
            CardDisplay cardDisplay = card.GetComponent<CardDisplay>();
            cardDisplay.setCardValues(level);
            i++;
        }
    }
}
