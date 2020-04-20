using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    private PNJHealth pnjHealth;

    bool canMakeDmgPlayer = false;
    bool canMakeDmgMeca = false;

    Animator anim;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        pnjHealth = FindObjectOfType<PNJHealth>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canMakeDmgPlayer = true;
            anim.SetBool("hitting", true);
        }
        else if (other.CompareTag("PNJ"))
        {
            canMakeDmgMeca = true;
            anim.SetBool("hitting", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canMakeDmgPlayer = false;
            anim.SetBool("hitting", false);
        }
        else if (other.CompareTag("PNJ"))
        {
            canMakeDmgMeca = false;
            anim.SetBool("hitting", false);
        }
    }

    void TakeDmg()
    {
        if (canMakeDmgPlayer)
        {
            playerHealth.TakeDmg();
        }
        else if (canMakeDmgMeca)
        {
            pnjHealth.TakeDmg();
        }
    }
}
