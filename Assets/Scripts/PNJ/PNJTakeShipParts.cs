using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTakeShipParts : MonoBehaviour
{
    int shipPartsGived = 0;
    const int maxShipParts = 5;
    bool canGiveShipParts = false;
    PlayerTakeAndDropObjects playerTakeAndDropObjects;

    [SerializeField] float installingTime = 20;
    float installingTimer = 0;

    bool isTheTarget = false;

    Animator anim;

   [SerializeField] RepairationBar repairBar;
    [SerializeField] float maxInstallingTime = 20;

    void Start()
    {
        playerTakeAndDropObjects = FindObjectOfType<PlayerTakeAndDropObjects>();
        anim = GetComponent<Animator>();
        installingTimer = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("ici");
            canGiveShipParts = true;
            playerTakeAndDropObjects.blockDrop();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            canGiveShipParts = false;
        }
    }

    void Update()
    {
        repairBar.setRepairTime(installingTimer, maxInstallingTime);

        if (Input.GetKeyDown("e") && canGiveShipParts)
        {
           
            playerTakeAndDropObjects.removeShipParts();
            shipPartsGived++;
            isTheTarget = true;
            anim.transform.Rotate(0, 180, 0);
            canGiveShipParts = false;
            playerTakeAndDropObjects.StopTakeAnim();
        }

        if(isTheTarget)
        {
            installingTimer += Time.deltaTime;
            Debug.Log(installingTimer);
            anim.SetBool("StopRepairing", true);
            if (installingTimer>=maxInstallingTime)
            {
                installingTimer = 0;
                isTheTarget = false;
               anim.transform.Rotate(0, 180, 0);
                anim.SetBool("StopRepairing", false);
                
            }
        }
        
        if (shipPartsGived == maxShipParts)
        {
            Time.timeScale = 0;
        }
    }

    public bool TellIfTarget()
    {
        return isTheTarget;
    }

    void ActivateRepairAnim()
    {
        anim.SetBool("StartRepairing", true);
    }

    void DisableRepairAnim()
    {
        anim.SetBool("StartRepairing", false);
    }

}
