﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("destroy collision");
            EnnemyHealth ennemy;
            ennemy = collision.GetComponent<EnnemyHealth>();
            //ennemy.DestroyBecauseOutOfPlace();
        }
    }
}