using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Opponent Card", menuName = "Cards/OpponentCard")]
public class OpponentCard : ScriptableObject
{
    public int level, health;
    public new string name;
    public float attack, defense, speed;
    public Sprite artwork;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Print()
    {
        Debug.Log("Card name: " + name);
    }
}
