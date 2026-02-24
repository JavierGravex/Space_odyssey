using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // GameSettings.Load();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("level_01");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

}
