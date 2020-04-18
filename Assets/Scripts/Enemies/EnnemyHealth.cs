using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    float health = 100f;
    float dmg = 10f;


    private void Update()
    {
        if (health <= 0)
        {
            Score.GetEnnemyPoint();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Score.GetBulletPoint();
            health -= dmg;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Score.GetBulletPoint();
            health -= dmg;
        }
    }
}
