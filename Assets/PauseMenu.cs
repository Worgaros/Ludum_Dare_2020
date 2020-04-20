using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool isPaused = false;

    private void Update()
    {

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ActivatePauseMenu();
        }
    }

    public void ActivatePauseMenu()
    {
        pausePanel.SetActive(true);
        isPaused = true;
    }

    public void DesactivatePanelMenu()
    {
        pausePanel.SetActive(false);
        isPaused = false;
    }
}
