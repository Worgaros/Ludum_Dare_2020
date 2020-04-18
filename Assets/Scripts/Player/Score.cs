using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    
    static float score = 0f;
    static float oxygenPoint = 10f;
    static float bulletPoint = 10f;
    static float ennemyPoint = 50f;
    static float shipPartPoint = 100f;
    static float ennemyBulletPoint = 10f;

    private void Update()
    {
        scoreText.text = score.ToString();
    }

    public static void GetOxygenPoint()
    {
        score += oxygenPoint;
    }
    public static void GetBulletPoint()
    {
        score += bulletPoint;
    }
    public static void GetEnnemyPoint()
    {
        score += ennemyPoint;
    }
    public static void GetShipPartPoint()
    {
        score += shipPartPoint;
    }
    public static void GetEnnemyBulletPoint()
    {
        score += ennemyBulletPoint;
    }
}
