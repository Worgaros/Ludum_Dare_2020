﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePosition;

    float fireRate;
    float nextFire;

    bool isShooting = false;
    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
    }

    private void Update()
    {
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (isShooting)
        {
            if (Time.time > nextFire)
            {
                Instantiate(bullet, firePosition.position,firePosition.rotation);
                nextFire = Time.time + fireRate;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            isShooting = true;
        }
    }
}
