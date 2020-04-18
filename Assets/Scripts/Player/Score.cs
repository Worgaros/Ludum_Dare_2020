﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    static float score = 0f;
    static float oxygenPoint = 10f;
    static float bulletPoint = 10f;
    static float ennemyPoint = 50f;

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
}