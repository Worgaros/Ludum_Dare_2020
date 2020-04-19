using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{
    private Transform player;
    Transform mechanoTransform;
    PNJTakeShipParts mechano;
    private Rigidbody2D body;

    [SerializeField] float speed = 1f;

    bool isFollowing = false;
    bool followMechano = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
        mechanoTransform = FindObjectOfType<PNJTakeShipParts>().transform;
        mechano = FindObjectOfType<PNJTakeShipParts>();
    }

    void Update()
    {

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isFollowing = true;
        }
    }
}
