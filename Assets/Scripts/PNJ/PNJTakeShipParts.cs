using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJTakeShipParts : MonoBehaviour
{
    int shipPartsGived = 0;
    const int maxShipParts = 5;
    PlayerTakeAndDropObjects playerTakeAndDropObjects;

    void Start()
    {
        playerTakeAndDropObjects = FindObjectOfType<PlayerTakeAndDropObjects>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("player") && Input.GetKeyDown("e"))
        {
            playerTakeAndDropObjects.removeShipParts();
            shipPartsGived++;
        }
    }

    void Update()
    {
        if (shipPartsGived == maxShipParts)
        {
            Time.timeScale = 0;
        }
        //Debug.Log(shipPartsGived);
    }
}
