using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    
    [SerializeField] public MainCardTween mainCardTween;
    [SerializeField] public Animator cardAnimationController;
    [SerializeField] public Animator playerAnimatorController;
    [SerializeField] public Animator enemyAnimatorController;

    [SerializeField] public GameObject healthBarsCanvas;
    
    [SerializeField] public TextMeshPro levelText;
    [SerializeField] public TextMeshPro nameText;

    [SerializeField] public TextMeshPro healthText;
    [SerializeField] public TextMeshPro speedText;
    [SerializeField] public TextMeshPro attackText;
    [SerializeField] public TextMeshPro defenseText;
    // [SerializeField] public TextMeshPro rewardText;
    // [SerializeField] public Image rewardImage;


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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && 
            Physics.Raycast(ray, out var hit) && 
            (hit.transform.name == "Card1" || hit.transform.name == "Card2" || hit.transform.name == "Card3"))
        { 
            StartCoroutine(SelectActionCoroutine());
        }
    }

    void Start()
    {
        cardAnimationController.speed = 0;
        StartCoroutine(AnimateCard());
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
        //rewardText.text = reward.name;
        //Debug.Log(reward.srcIcon);
        //rewardImage.sprite = Resources.Load<Sprite>(reward.srcIcon);
    }
    
    private void SelectAction()
    {
        enemyStatsManager.InitStats(unitStatisticsManager.unitStatistics);
        cameraHandle.isIntro = true;
        userInterface.InitHealthBars();

        cardManager.mainSceneLight.SetActive(true);
        cardManager.isActive = false;
        statsManager.isActive = false;
        statsManager.statsCard.SetActive(false);
        playerManager.rewardGame = reward;

        cardManager.ResetUnits();
    }
    
    IEnumerator AnimateCard()
    {
        yield return new WaitForSeconds(0.05F);
        cardAnimationController.speed = 0.65F;
    }
    
    IEnumerator SelectActionCoroutine()
    {
        yield return new WaitForSeconds(0.15F);
        SelectAction();
        healthBarsCanvas.SetActive(true);
        playerAnimatorController.speed = 1;
        enemyAnimatorController.speed = 1;
        mainCardTween.OnClose();
    }
}