using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public Text levelText;
    [SerializeField] public Text nameText;
    [SerializeField] public Image artwork;

    public Slider healthSlider;
    public Slider attackSlider;
    public Slider defenseSlider;
    public Slider speedSlider;

    public UnitStatistics unitStatistics;

    public Button selectButton;
    void Start()
    {
        Button btn = selectButton.GetComponent<Button>();
        btn.onClick.AddListener(SelectAction);
    }

    public void setCardValues(int level)
    {
        unitStatistics = new UnitStatistics(level);

        levelText.text = "Level " + level;
        nameText.text = "Enemy";
        healthSlider.value = unitStatistics.Health;
        attackSlider.value = unitStatistics.Attack;
        defenseSlider.value = unitStatistics.Defense;
        speedSlider.value = unitStatistics.Speed;
    }

    void SelectAction()
    {
        DataSaver.saveData(unitStatistics, "enemy");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
