using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeAndDropObjects : MonoBehaviour
{
    bool haveO2 = false;
    bool haveShipPiece = false;
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("e") && other.CompareTag("Ship") && !haveShipPiece)
        {
            Destroy(other.gameObject);
            haveShipPiece = true;
        }
    }
}
