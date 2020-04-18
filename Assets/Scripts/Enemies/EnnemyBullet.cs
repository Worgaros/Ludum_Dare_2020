using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D body;

    [SerializeField] float speed = 1f;

    bool isShooting = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        body.velocity = (player.transform.position - transform.position).normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
