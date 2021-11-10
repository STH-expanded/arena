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

    public UnitStatisticsManager unitStatisticsManager;

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

    public void setCardValues(int level)
    {
        unitStatisticsManager.InitLevelUp(level);
        UnitStatistics stats = unitStatisticsManager.unitStatistics;

        levelText.text = "Level " + level;
        nameText.text = "Enemy";
        healthSlider.value = stats.Health;
        attackSlider.value = stats.Attack;
        defenseSlider.value = stats.Defense;
        speedSlider.value = stats.Speed;
    }

    void SelectAction()
    {

        /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
    }
}
