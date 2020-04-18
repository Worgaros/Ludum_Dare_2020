using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour
{
    Transform playerPosition;
    Vector2 player;
    bool move = false;
    [SerializeField] float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().transform;
        player = playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        player = playerPosition.position;
        if(move)
        {
            MoveToPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            move = true;
        }
    }

    void MoveToPlayer()
    {
        Debug.Log("move");
        transform.position = Vector3.Lerp(transform.position, player, Time.deltaTime*speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
