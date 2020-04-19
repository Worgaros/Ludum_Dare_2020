using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenCable : MonoBehaviour
{

    Rigidbody2D body;
    Transform playerPosition;
    [SerializeField] float cableSpeed = 5;
    bool canAttach = false;
    int numberOfUse = 0;
    [SerializeField] int maxNumberOfUse = 3;
    [SerializeField] GameObject oxygenBottle;

    PlayerOxygen playerOxygen;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerPosition = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(canAttach)
        {
            AttachToPlayer();
        }
        if(numberOfUse>=3)
        {
            Destroy(oxygenBottle);
        }
    }

    void AttachToPlayer()
    {
        body.velocity = (playerPosition.transform.position - transform.position).normalized * cableSpeed;
        if (Vector3.Distance(transform.position, playerPosition.transform.position) <= 2)
        {
            numberOfUse++;
            playerOxygen.ConnectingToBottle();
        }
        if (Vector3.Distance(transform.position, playerPosition.transform.position) > 2)
        {
            playerOxygen.DisconnectedFromBottle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            playerOxygen = collision.gameObject.GetComponent<PlayerOxygen>();
            canAttach = true;
           // numberOfUse++;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            canAttach = false;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.CompareTag("player"))
    //    {
    //        Debug.Log("collided");
    //        playerOxygen = collision.gameObject.GetComponent<PlayerOxygen>();
    //       // playerOxygen.ConnectingToBottle();
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("player"))
    //    {
    //        Debug.Log("collided");
    //        playerOxygen = collision.gameObject.GetComponent<PlayerOxygen>();
    //        //playerOxygen.DisconnectedFromBottle();
    //    }
    //}
}
