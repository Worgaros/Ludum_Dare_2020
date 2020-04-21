using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckWin : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    static float totalPart = 0f;
    [SerializeField] private TextMeshProUGUI partText;

    MenuManager MenuManager;

    private void Start()
    {
        totalPart = 0f;
        //winPanel.SetActive(false);
    }
    private void Update()
    {
        partText.text = totalPart.ToString("F0");

        if (totalPart >= 5)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public static void ShipRepair()
    {
        totalPart += 1;
    }
}
