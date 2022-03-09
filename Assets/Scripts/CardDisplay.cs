using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] public Animator cardAnimationController;
    
    [SerializeField] public TextMeshPro levelText;
    [SerializeField] public TextMeshPro nameText;

    [SerializeField] public TextMeshPro healthText;
    [SerializeField] public TextMeshPro speedText;
    [SerializeField] public TextMeshPro attackText;
    [SerializeField] public TextMeshPro defenseText;
    [SerializeField] public TextMeshPro rewardText;

    public CardManager cardManager;
    public CameraHandle cameraHandle;
    
    public UserInterface userInterface;

    public UnitStatisticsManager unitStatisticsManager;
    public UnitStatisticsManager enemyStatsManager;
    public Stats statsManager;
    
    public Reward reward;
    public PlayerManager playerManager;

    private void Awake()
    {
        unitStatisticsManager = GetComponent<UnitStatisticsManager>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(SelectActionCoroutine());
            }
        }
    }

    void Start()
    {
        cardAnimationController.speed = 0;
        StartCoroutine(AnimateCard());
        
        Debug.Log("Passed #1");
        cardManager.isActive = false;
    }

    public void SetCardValues(int level, string enemyName)
    {
        unitStatisticsManager.InitLevel(level);
        UnitStatistics stats = unitStatisticsManager.unitStatistics;

        levelText.text = $"LVL {level}";
        nameText.text = enemyName;
        healthText.text = stats.Health.ToString();
        attackText.text = stats.Attack.ToString();
        defenseText.text = stats.Defense.ToString();
        speedText.text = stats.Speed.ToString();
        // rewardText.text = reward.name;
    }
    
    IEnumerator AnimateCard()
    {
        yield return new WaitForSeconds(0.1F);
        cardAnimationController.speed = 0.6F;
    }
    
    IEnumerator SelectActionCoroutine()
    {
        yield return new WaitForSeconds(0.3F);
        SelectAction();
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
