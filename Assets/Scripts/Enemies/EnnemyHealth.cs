using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    [SerializeField]float health = 100f;
    float dmg = 10f;

    EnnemiesSpawning EnnemiesSpawning;

    Animator shootingEnnemyAnim;
    Animator runningEnnemyAnim;

    private void Start()
    {
        EnnemiesSpawning = FindObjectOfType<EnnemiesSpawning>();
        if(gameObject.CompareTag("shootingEnnemy"))
        {
            shootingEnnemyAnim = GetComponentInChildren<Animator>();
        }
        if (gameObject.CompareTag("runningEnnemy"))
        {
            runningEnnemyAnim = GetComponentInChildren<Animator>();
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Score.GetBulletPoint();
            health -= dmg;
            if (gameObject.CompareTag("shootingEnnemy"))
            {
                shootingEnnemyAnim.SetTrigger("isHurt");
            }
            if (gameObject.CompareTag("runningEnnemy")&&runningEnnemyAnim != null)
            {
                runningEnnemyAnim.SetTrigger("isHurt");
            }
        }
    }

    //public void DestroyBecauseOutOfPlace()
    //{
    //    Destroy(gameObject);
    //}

    void Death()
    {
        Vector2 deathPosition = new Vector2(transform.position.x, transform.position.y);
        EnnemiesSpawning.SpawnOxygen(deathPosition);
        Score.GetEnnemyPoint();
        Destroy(gameObject);
    }
}
