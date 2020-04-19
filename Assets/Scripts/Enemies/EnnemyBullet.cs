using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyBullet : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D body;

    [SerializeField] float speed = 1f;

    bool isShooting = false;

    PNJTakeShipParts mechano;
    bool followMechano = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        mechano = FindObjectOfType<PNJTakeShipParts>();
    }

    void Update()
    {
        followMechano = mechano.TellIfTarget();

        if(!followMechano)
        {
            body.velocity = (player.transform.position - transform.position).normalized * speed; 
        }
        if(followMechano)
        {
            body.velocity = (mechano.gameObject.transform.position - transform.position).normalized * speed;
        }
        Destroy(gameObject, 3f); ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Score.GetEnnemyBulletPoint();
        }
        Destroy(gameObject);
    }
}
