using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    GameData gameData;

    public CardManager cardManager;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;

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

        playerManager.unitStatisticsManager.InitStats(gameData.unitStatistics);
        cardManager.InitCards(gameData.level);
    }

    void Update()
    {
        if (cardManager.isActive)
            return;

        if (playerManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
        {
            Lose();
        }
        else if (enemyManager.unitStatisticsManager.unitStatistics.CurrentHealth == 0)
        {
            Win();
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
    }

    void Lose()
    {
        Debug.Log("Lose");

        gameData.score = 0;
        gameData.level = 1;
        gameData.unitStatistics = new UnitStatistics();

        SaveLoad.SaveData(gameData);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
