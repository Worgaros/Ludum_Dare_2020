using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    static float life = 100f;
    static float dmg = 0.01f;
    static float health = 10f;
    
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        life = 100f;
    }
    private void Update()
    {
       // healthText.text = life.ToString("F0");
    }

    public static void TakeDmg()
    {
        life -= dmg;
        
        if (life <= 0f)
        {
            life = 0f;
            // gameOverPanel.SetActive(true);
        }
    }

    public static void TakeHealth()
    {
        life += health;
       
        if (life >= 100f)
        {
            life = 100f;
        }
    }
}
