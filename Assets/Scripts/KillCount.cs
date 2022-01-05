using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    public GameData gameData;
    public Text killCount;
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.persistentDataPath + "/gameData.save";
        if (File.Exists(path))
        {
            gameData = SaveLoad.LoadData();
            if (gameData.score > 0)
            {
                killCount.text = "Killing count : " + gameData.score;
            }
            else
            {
                killCount.text = "No kill yet.";
            }
        }
    }
}
