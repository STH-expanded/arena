using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    public GameData gameData;
    public GameObject achievementList;

    public void Start()
    {
        string path = Application.persistentDataPath + "/gameData.save";
        if (File.Exists(path))
        {
            gameData = SaveLoad.LoadData();
        }
        else
        {
            gameData = new GameData();
            gameData.unitStatistics = new UnitStatistics();
            gameData.highScore = 0;
            gameData.score = 0;
            gameData.level = 1;

            SaveLoad.SaveData(gameData);
        }
        
        for (int i = 1; i < gameData.achievements.Length + 1; i++)
        {
            if (gameData.achievements != null)
            {
                bool a = gameData.achievements[i - 1];
                GameObject obj = GameObject.Find("Achievement" + i);
                obj.GetComponentInChildren<UnityEngine.UI.Text>().color = a ? Color.white : Color.grey;
            }
        }
        GameObject.Find("AchievementsMenu").SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
