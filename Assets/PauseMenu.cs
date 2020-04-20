using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool isPaused = false;

    private void Update()
    {

        // if (isPaused)
        // {
        //     Time.timeScale = 0f;
        // }
        // else
        // {
        //     Time.timeScale = 1f;
        // }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                ActivatePauseMenu();
            }
            else if (isPaused)
            {
                DesactivatePanelMenu();
            }
        }
    }

    public void ActivatePauseMenu()
    {
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void DesactivatePanelMenu()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
