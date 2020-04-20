using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    PlayerHealth playerHealth;

    bool canMakeDmg = false;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canMakeDmg = true;
            //lance anim
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canMakeDmg = false;
        }
    }

    void TakeDmg()
    {
        if (canMakeDmg)
        {
            playerHealth.TakeDmg();
        }
    }
}
