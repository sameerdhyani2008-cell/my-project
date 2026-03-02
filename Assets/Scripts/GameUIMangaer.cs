using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    public Transform player;

    public void SaveGame()
    {
        SaveSystem.SaveGame(player);
    }

    public void LoadGame()
    {
        SaveSystem.LoadGame(player);
    }

    void Start()
    {
        if (GameState.shouldLoadGame)
        {
            SaveSystem.LoadGame(player);
        }
    }
}