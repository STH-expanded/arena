using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public OpponentCard card;

    [SerializeField] public Text levelText;
    [SerializeField] public Text nameText;

    [SerializeField] public Image artwork;

    public Slider healthSlider;
    public Slider speedSlider;
    public Slider attackSlider;
    public Slider defenseSlider;

    // Use this for initialization
    void Start()
    {
        setCardValues();
    }

    private void setCardValues()
    {
        levelText.text = card.level.ToString();
        nameText.text = card.name;
        healthSlider.value = card.health;
        speedSlider.value = card.speed;
        attackSlider.value = card.attack;
        defenseSlider.value = card.defense;
    }
}
