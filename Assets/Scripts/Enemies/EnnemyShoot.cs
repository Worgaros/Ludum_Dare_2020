using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    float fireRate;
    float nextFire;

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
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
