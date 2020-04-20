using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckWin : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    static float totalPart = 0f;
    [SerializeField] private TextMeshProUGUI partText;

    private void Start()
    {
        winPanel.SetActive(false);
    }
    private void Update()
    {
        partText.text = totalPart.ToString("F0");

        if (totalPart >= 5)
        {
            winPanel.SetActive(true);
        }
    }

    public static void ShipRepair()
    {
        totalPart += 1;
    }
}
