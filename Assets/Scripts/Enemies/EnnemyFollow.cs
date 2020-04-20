using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{
    private Transform player;
    Transform mechanoTransform;
    PNJTakeShipParts mechano;
    private Rigidbody2D body;

    [SerializeField] LayerMask whatIsGround;

    [SerializeField] float speed = 1f;

    bool isFollowing = false;
    bool followMechano = false;

    bool destroy = false;
    float checkRadius = 0.1f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        mechanoTransform = FindObjectOfType<PNJTakeShipParts>().transform;
        mechano = FindObjectOfType<PNJTakeShipParts>();
    }

    private void FixedUpdate()
    {
        if (!followMechano)
        {
            Vector2 lookDirection = player.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
            body.rotation = angle;
        }
        if(followMechano)
        {
            Vector2 lookDirection = mechanoTransform.position - transform.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
            body.rotation = angle;
        }

    }

    void Update()
    {

       destroy = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsGround);

        followMechano = mechano.TellIfTarget();

        if (isFollowing&&!followMechano)
        {
            body.velocity = (player.transform.position - transform.position).normalized * speed;
            //Debug.Log("move");
        }
        if(followMechano)
        {
            body.velocity = (mechanoTransform.transform.position - transform.position).normalized * speed;
        }

        if(destroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isFollowing = true;
        }
    }
}
