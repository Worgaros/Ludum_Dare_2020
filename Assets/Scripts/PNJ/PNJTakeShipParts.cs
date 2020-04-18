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
            playerTakeAndDropObjects.removeShipParts();
            shipPartsGived++;
            canGiveShipParts = false;
        }
        
        if (shipPartsGived == maxShipParts)
        {
            Time.timeScale = 0;
        }
    }
}
