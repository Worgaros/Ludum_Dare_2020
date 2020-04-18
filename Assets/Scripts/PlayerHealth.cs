using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    static float life = 100f;
    static float dmg = 10f;
    static float health = 10f;

    public static void TakeDmg()
    {
        life -= dmg;
    }

    public static void TakeHealth()
    {
        life += health;
    }
}
