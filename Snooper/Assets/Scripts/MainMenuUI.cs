using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public string level1SceneName = "Level1"; // The name of your first level scene
    public string level2SceneName = "Level2"; // The name of your second level scene
    public string level3SceneName = "Level3"; // The name of your third level scene
    public string mainMenuSceneName = "MainMenu"; // The name of your main menu scene

    // Add public functions to be called from UI buttons
    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1SceneName);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2SceneName);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(level3SceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
