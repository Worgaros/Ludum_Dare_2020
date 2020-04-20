using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PNJHealth : MonoBehaviour
{
    static float dmg = 2f;
    static float health = 100f;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        health = 100f;
    }
    private void Update()
    {
        healthText.text = health.ToString("F0");

        if (health <= 0f)
        {
            health = 0f;
        }
    }

    public void TakeDmg()
    {
        health -= dmg;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ennemyBullet")
        {
            TakeDmg();
        }
    }
}
