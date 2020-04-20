using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    PlayerHealth playerHealth;

    bool canMakeDmg = false;

    Animator anim;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canMakeDmg = true;
            anim.SetBool("hitting", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canMakeDmg = false;
            anim.SetBool("hitting", false);
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
