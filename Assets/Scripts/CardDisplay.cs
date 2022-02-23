using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public Text levelText;
    [SerializeField] public Text nameText;
    [SerializeField] public Image artwork;

    [SerializeField] public Text healthText;
    [SerializeField] public Text speedText;
    [SerializeField] public Text attackText;
    [SerializeField] public Text defenseText;
    [SerializeField] public Text rewardText;

    public CardManager cardManager;
    public CameraHandle cameraHandle;

    public Slider healthSlider;
    public Slider speedSlider;
    public Slider attackSlider;
    public Slider defenseSlider;

    public UserInterface userInterface;

    public UnitStatisticsManager unitStatisticsManager;
    public UnitStatisticsManager enemyStatsManager;
    public Stats statsManager;


    public Button selectButton;

    public Reward reward;
    public PlayerManager playerManager;

    private void Awake()
    {
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
    }

    void Start()
    {
        Button btn = selectButton.GetComponent<Button>();
        btn.onClick.AddListener(SelectAction);
    }

    public void SetCardValues(int level, string enemyName  )
    {
        unitStatisticsManager.InitLevel(level);
        UnitStatistics stats = unitStatisticsManager.unitStatistics;

        levelText.text = string.Format("Level {0}", level);
        nameText.text = enemyName;

        healthSlider.value = stats.Health;
        healthText.text = stats.Health.ToString();

        attackSlider.value = stats.Attack;
        attackText.text = stats.Attack.ToString();

        defenseSlider.value = stats.Defense;
        defenseText.text = stats.Defense.ToString();

        speedSlider.value = stats.Speed;
        speedText.text = stats.Speed.ToString();
        rewardText.text = reward.name;

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
