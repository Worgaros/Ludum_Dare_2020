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

    void Start()
    {
        playerTakeAndDropObjects = FindObjectOfType<PlayerTakeAndDropObjects>();
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
        if (Input.GetKeyDown("e") && canGiveShipParts)
        {
            installingTimer = installingTime;
            playerTakeAndDropObjects.removeShipParts();
            shipPartsGived++;
            isTheTarget = true;
            canGiveShipParts = false;
        }

        if(isTheTarget)
        {
            installingTimer -= Time.deltaTime;
            if(installingTimer<=0)
            {
                isTheTarget = false;
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

}
