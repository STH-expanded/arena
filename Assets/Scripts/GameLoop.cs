using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    GameData gameData;

    public CardManager cardManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public CameraHandle cameraHandle;
    private int winBuffer = 0;

    public bool isIntro = true;

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
        
        playerManager.unitStatisticsManager.InitStats(gameData.unitStatistics);
        cardManager.InitCards(gameData.level);
    }

    void Update()
    {
        if (enemyManager.transform.position.z <= 5)
        {
            enemyManager.isIntro = false;
            playerManager.isIntro = false;
        }
        
        if (cardManager.isActive)
            return;

        if (playerManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
        {
            Lose();
        }
        else if (enemyManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
        {
            cameraHandle.isEnemyDead = true;
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

        gameData.score += 1;
        gameData.level += 1;
        if (gameData.score > gameData.highScore) gameData.highScore = gameData.score;
        gameData.unitStatistics = playerManager.unitStatisticsManager.unitStatistics;

        SaveLoad.SaveData(gameData);
        
        cardManager.InitCards(gameData.level);
        // reset for the next game :
        cameraHandle.isEnemyDead = false;
        enemyManager.isIntro = true;
        playerManager.isIntro = true;
    }

    void Lose()
    {
        Debug.Log("Lose");

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
