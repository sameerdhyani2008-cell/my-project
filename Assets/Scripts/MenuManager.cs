using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        GameState.shouldLoadGame = false;
        SceneManager.LoadScene("GameScene1");
    }

    public void LoadGame()
    {
        GameState.shouldLoadGame = true;
        SceneManager.LoadScene("GameScene1");
    }
}