using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    static float totalPart = 0f;

    private void Start()
    {
        winPanel.SetActive(false);
    }
    private void Update()
    {
        ShipRepair();

        if(totalPart >= 5)
        {
            winPanel.SetActive(true);
        }
    }

    public static void ShipRepair()
    {
        totalPart += 1;
    }
}
