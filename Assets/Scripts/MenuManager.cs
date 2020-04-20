using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private string sceneName;


    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 0f;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
