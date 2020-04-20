using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePosition;

    [SerializeField]float fireRate;

    Animator anim;
    float nextFire;

    bool isShooting = false;

    [SerializeField] AudioSource blaster;
    private void Start()
    {
        fireRate = 1f;
        nextFire = Time.time;
        anim = GetComponent<Animator>();
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
                anim.SetTrigger("shoot");
                Instantiate(bullet, firePosition.position,firePosition.rotation);
                blaster.Play();
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
