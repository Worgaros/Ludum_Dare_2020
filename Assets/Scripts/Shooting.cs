using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] Transform firePosition;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
      GameObject bullet =  Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
      Rigidbody2D bulletBody =  bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(firePosition.up * bulletForce, ForceMode2D.Impulse);
    }
}
