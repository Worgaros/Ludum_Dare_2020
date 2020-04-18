using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    static float health = 100f;
    static float dmg = 10f;

    public static void TakeDmg()
    {
        health -= dmg;
    }
}
