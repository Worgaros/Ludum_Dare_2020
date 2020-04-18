using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Rigidbody2D body;

    private int playerDistance = 10;
    [SerializeField] float speed = 1f;

    bool isFollowing = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        // var direction = Vector3.Distance(transform.position, player.transform.position);

        if (isFollowing)
        {
            body.velocity = (player.transform.position - transform.position).normalized * speed;
            Debug.Log("move");
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
