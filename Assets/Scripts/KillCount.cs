using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public GameData gameData;
    public Text killCount;

    public int countNumber;
    // Start is called before the first frame update
    private void Update()
    {
        string path = Application.persistentDataPath + "/gameData.save";
        if (File.Exists(path))
        {
            gameData = SaveLoad.LoadData();
            if (gameData.score > 0)
            {
                countNumber = gameData.score;
                killCount.text = "Killing count : " + countNumber;
            }
            else
            {
                killCount.text = "";
            }
        }
    }

    void Start()
    {
        string path = Application.persistentDataPath + "/gameData.save";
        if (File.Exists(path))
        {
            gameData = SaveLoad.LoadData();
            if (gameData.score > 0)
            {
                countNumber = gameData.score;
                killCount.text = "Killing count : " + countNumber;
            }
            else
            {
                killCount.text = "";
            }
        }
    }
}
