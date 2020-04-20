﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    static float life = 100f;
    static float dmg = 2f;
    static float oxygenDmg = 0.1f;
    static float health = 10f;
    static float bulletDmg = 2f;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI healthText;
    
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        life = 100f;
        gameOverPanel.SetActive(false);
    }
    private void Update()
    {
       healthText.text = life.ToString("F0");

        if (life <= 0f)
        {
            life = 0f;
            GameOver();
        }
    }

    public void TakeDmg()
    {
        Debug.Log("tookDamage");
        life -= dmg;
        Debug.Log(life);
    }

    void BulletDmg()
    {
        life -= bulletDmg;
    }

    public void OxyDmg()
    {
        life -= oxygenDmg;
    }
    public void TakeHealth()
    {
        life += health;
       
        if (life >= 100f)
        {
            life = 100f;
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ennemyBullet")
        {
            BulletDmg();
        }
    }
}
