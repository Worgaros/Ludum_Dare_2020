using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    float health = 100f;
    float dmg = 10f;

    EnnemiesSpawning EnnemiesSpawning;

    private void Start()
    {
        EnnemiesSpawning = FindObjectOfType<EnnemiesSpawning>();
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death();
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

    public void DestroyBecauseOutOfPlace()
    {
        Destroy(gameObject);
    }

    void Death()
    {
        Vector2 deathPosition = new Vector2(transform.position.x, transform.position.y);
        EnnemiesSpawning.SpawnOxygen(deathPosition);
        Score.GetEnnemyPoint();
        Destroy(gameObject);
    }
}
