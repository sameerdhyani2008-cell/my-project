using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string path = Application.persistentDataPath + "/save.json";

    public static void SaveGame(Transform player)
    {
        SaveData data = new SaveData();
        data.playerX = player.position.x;
        data.playerY = player.position.y;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);

        Debug.Log("Game Saved");
    }

    public static void LoadGame(Transform player)
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            player.position = new Vector2(data.playerX, data.playerY);
            Debug.Log("Game Loaded");
        }
    }
}