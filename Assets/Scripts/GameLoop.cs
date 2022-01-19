using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    GameData gameData;

    public CardManager cardManager;
    public Stats statsPlayers;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public CameraHandle cameraHandle;
    private int winBuffer = 0;

    void Start()
    {
        string path = Application.persistentDataPath + "/gameData.save";
        if (File.Exists(path))
        {
            gameData = SaveLoad.LoadData();
        }
        else
        {
            Debug.Log("Save file not found");
            Application.Quit();
        }

        enemyManager.isIntro = true;
        playerManager.isIntro = true;
        playerManager.isOutro = false;

        playerManager.unitStatisticsManager.InitStats(gameData.unitStatistics);
        cardManager.InitCards(gameData.level);
        statsPlayers.InitStats(playerManager);
    }

    void Update()
    {
        if (enemyManager.transform.position.z <= 3)
        {
            cameraHandle.isIntro = false;
            enemyManager.isIntro = false;
            playerManager.isIntro = false;
        }
        
        if (cardManager.isActive)
            return;

        if (playerManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
        {
            cameraHandle.isPlayerDead = true;
            enemyManager.isOutro = true;
            Lose();
        }
        else if (enemyManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
        {
            cameraHandle.isEnemyDead = true;
            playerManager.isOutro = true;
            if (winBuffer < 620)
            {
                winBuffer += 1;
                playerManager.startGameBuffer = 0;
                enemyManager.startGameBuffer = 0;
            }
            else
            {
                winBuffer = 0;
                Win();
            }
        }
    }

    void Win()
    {
        Debug.Log("Win");
        // Result Reward
        Debug.Log(playerManager.rewardGame.applyReward(playerManager));

        gameData.numberOfGamePlayed += 1;
        gameData.score += 1;
        gameData.level += 1;
        if (gameData.score > gameData.highScore) gameData.highScore = gameData.score;
        gameData.unitStatistics = playerManager.unitStatisticsManager.unitStatistics;

        // Achievements
        if (gameData.achievements != null)
        {
            if (gameData.numberOfGamePlayed == 1) gameData.achievements[0] = true;
            if (gameData.numberOfGamePlayed == 5) gameData.achievements[1] = true;
            if (gameData.numberOfGamePlayed == 10) gameData.achievements[2] = true;
            if (enemyManager.unitStatisticsManager.unitStatistics.Level >= 10) gameData.achievements[2] = true;
            if (gameData.score == 1) gameData.achievements[3] = true;
            if (gameData.score == 5) gameData.achievements[4] = true;
            if (gameData.score == 10) gameData.achievements[5] = true;
        }
        
        SaveLoad.SaveData(gameData);
        
        GameObject.Find("Canvas").SetActive(false);
        cardManager.InitCards(gameData.level);
        // reset for the next game :
        cameraHandle.isEnemyDead = false;
        enemyManager.isIntro = true;
        playerManager.isOutro = true;
        statsPlayers.InitStats(playerManager);
    }

    void Lose() 
    {
        Debug.Log("Lose");

        gameData.numberOfGamePlayed += 1;
        gameData.score = 0;
        gameData.level = 1;
        gameData.unitStatistics = new UnitStatistics();

        SaveLoad.SaveData(gameData);
        
        Invoke("DeathCountdown", 5);
    }
    
    private void DeathCountdown()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
