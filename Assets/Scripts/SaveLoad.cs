using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{
    public static void SaveData(GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/gameData.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gameData = formatter.Deserialize(stream) as GameData;

            stream.Close();

            return gameData;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}