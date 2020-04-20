using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private GameObject panelStartGame;
    private bool isPaused = true;

    private void Start()
    {
        ActivatePanel();
    }

    private void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
    }

    public void ActivatePanel()
    {
        panelStartGame.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DeactivatePanel()
    {
        panelStartGame.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
