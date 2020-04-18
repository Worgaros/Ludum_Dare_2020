using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] Transform firePosition;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletForce = 5f;
    [SerializeField] int bulletNumber = 3;
    [SerializeField] float bulletTime = 0.1f;
    float bulletTimer = 0;
    bool canShoot = false;
    bool shooting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    enum State
    {
        NOT_SHOOTING,
        SHOOTING,
        COOLDOWN
    }

    State state = State.NOT_SHOOTING;

    // Update is called once per frame
    void Update()
    {
        
        switch(state)
        {
            case State.NOT_SHOOTING:
                bulletTimer = bulletTime;
                if(Input.GetButtonDown("Fire1"))
                {
                    shooting = true;
                }
                if(Input.GetButtonUp("Fire1"))
                {
                    shooting = false;
                }

                if(shooting)
                {
                    state = State.SHOOTING;
                }

                break;
            case State.SHOOTING:
                Shoot();
                state = State.COOLDOWN;
                if (Input.GetButtonUp("Fire1"))
                {
                    shooting = false;
                    state = State.NOT_SHOOTING;
                }
                break;
            case State.COOLDOWN:
                if (Input.GetButtonUp("Fire1"))
                {
                    shooting = false;
                    state = State.NOT_SHOOTING;
                }
                bulletTimer -= Time.deltaTime;
                if(bulletTimer<=0)
                {
                    state = State.NOT_SHOOTING;
                }
                break;
        }





        //if (Input.GetButton("Fire1"))
        //{
            
        //    bulletTimer = bulletTime;
           
        //    {
        //        Shoot();
        //        canShoot = false;
        //        bulletTimer -= Time.deltaTime;
        //        if(bulletTimer<=0)
        //        {
        //            canShoot = true;
        //            bulletTimer = bulletTime;
        //        }

        //    }
        //}
    }

    void Shoot()
    {
       
          GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
          Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
          bulletBody.AddForce(firePosition.up * bulletForce, ForceMode2D.Impulse);
         
    }

   
}
