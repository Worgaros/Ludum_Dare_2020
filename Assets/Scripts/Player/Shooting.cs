using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
    bool shotBlocked = false;
    bool shotBlockedTakeParts = false;

    float overHeat =0;
    [SerializeField] float maxOverheat;
    bool startOverHeat = false;
    bool startCooling = false;
    bool isOverHeating = false;

    [SerializeField] float gunDispertion = 1;
    [SerializeField] float gunBulletAngle = 1;

    [SerializeField] float innaccuracy = 0.1f;

    Animator anim;
    [SerializeField] Animator overheatTextAnim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
         
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
      //  Debug.Log("overHeat"+overHeat);
        switch(state)
        {
            case State.NOT_SHOOTING:
                anim.SetBool("IsShooting", false);
                bulletTimer = bulletTime;
                if(Input.GetButtonDown("Fire1"))
                {
                    shooting = true;
                    if (!isOverHeating)
                    {
                        startOverHeat = true;
                        startCooling = false;
                    }
                   // OverHeating();

                }
                if(Input.GetButtonUp("Fire1"))
                {
                    //Debug.Log("buttonUp");
                    //shooting = false;
                   
                    //startCooling = true;
                    //startOverHeat = false;
                    // Cooling();
                }

                if(shooting)
                {
                    state = State.SHOOTING;
                }

                break;
            case State.SHOOTING:
                Shoot();
                if (!isOverHeating && !shotBlocked && !shotBlockedTakeParts)
                {
                    anim.SetBool("IsShooting", true);
                }
                state = State.COOLDOWN;
                if (Input.GetButtonUp("Fire1"))
                {
                    //Debug.Log("buttonUp");
                    shooting = false;

                    startCooling = true;
                    startOverHeat = false;
                    shooting = false;
                    state = State.NOT_SHOOTING;
                }
                break;
            case State.COOLDOWN:
                if (Input.GetButtonUp("Fire1"))
                {
                    //Debug.Log("buttonUp");
                    shooting = false;

                    startCooling = true;
                    startOverHeat = false;
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

        OverHeating();
        Cooling();

        //Debug.Log(shotBlocked);


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

    void OverHeating()
    {
        if (startOverHeat&&!startCooling)
        {
            overHeat += Time.deltaTime;
            if(overHeat>=maxOverheat)
            {
                overheatTextAnim.SetBool("isOverHeating", true);
                BlockShoot();
                overHeat = maxOverheat;
                isOverHeating = true;
                startOverHeat = false;
            }
        }
    }
    void Cooling()
    {
        if (startCooling&&!startOverHeat)
        {
            //Debug.Log("cooling");
            overHeat -= Time.deltaTime*2;
            if (overHeat <= 0)
            {
                overheatTextAnim.SetBool("isOverHeating", false);
                UnblockShoot();
                overHeat = 0;
                isOverHeating = false;
                startCooling = false;
            }
        }
    }

    void Shoot()
    {
        if (!shotBlocked && !shotBlockedTakeParts)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            //
            bullet.transform.position += (Vector3)Random.insideUnitCircle * gunDispertion;
            
            
           // firePosition.rotation = Quaternion.AngleAxis(angle, firePosition.up);
            
            //
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(firePosition.up * bulletForce, ForceMode2D.Impulse);
            
        }
    }

   public void BlockShoot()
    {
        shotBlocked = true;
    }
    public void UnblockShoot()
    {
        shotBlocked = false;
    }
    
    public void BlockShootTakeParts()
    {
        shotBlockedTakeParts = true;
    }
    public void UnblockShootTakeParts()
    {
        shotBlockedTakeParts = false;
    }
}
