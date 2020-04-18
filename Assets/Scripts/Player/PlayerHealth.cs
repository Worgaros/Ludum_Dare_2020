using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    static float life = 100f;
    static float dmg = 10f;
    static float health = 10f;


    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (life >= 0)
        {
           // gameOverPanel.SetActive(true);
        }
       

    }

    public static void TakeDmg()
    {
        life -= dmg;
    }

    public static void TakeHealth()
    {
        life += health;
    }
}
