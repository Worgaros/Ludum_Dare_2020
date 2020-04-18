using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeAndDropObjects : MonoBehaviour
{
    private bool haveShipPart = false;
    bool have1 = false;
    bool have2 = false;
    bool have3 = false;
    bool have4 = false;
    bool have5 = false;
    bool have6 = false;
    bool have7 = false;
    bool have8 = false;
    bool canDrop = false;
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject onePrefab;
    [SerializeField] GameObject twoPrefab;
    [SerializeField] GameObject threePrefab;
    [SerializeField] GameObject fourPrefab;
    [SerializeField] GameObject fivePrefab;
    [SerializeField] GameObject sixPrefab;
    [SerializeField] GameObject sevenPrefab;
    [SerializeField] GameObject heightPrefab;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("e") && other.CompareTag("1") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have1 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("2") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have2 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("3") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have3 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("4") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have4 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("5") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have5 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("6") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have6 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("7") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have7 = true;
            haveShipPart = true;
            canDrop = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("8") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have8 = true;
            haveShipPart = true;
            canDrop = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            canDrop = true;
        }
        if (have1 && Input.GetKeyDown("e") && canDrop)
        {
            have1 = false;
            haveShipPart = false;
            GameObject One = Instantiate(onePrefab, firePosition.position, firePosition.rotation);
        }
        else if (have2 && Input.GetKeyDown("e") && canDrop)
        {
            have2 = false;
            haveShipPart = false;
            GameObject Two = Instantiate(twoPrefab, firePosition.position, firePosition.rotation);
        }
        else if (have3 && Input.GetKeyDown("e") && canDrop)
        {
            have3 = false;
            haveShipPart = false;
            GameObject Three = Instantiate(threePrefab, firePosition.position, firePosition.rotation);
        }
        else if (have4 && Input.GetKeyDown("e") && canDrop)
        {
            have4 = false;
            haveShipPart = false;
            GameObject Four = Instantiate(fourPrefab, firePosition.position, firePosition.rotation);
        }
        else if (have5 && Input.GetKeyDown("e") && canDrop)
        {
            have5 = false;
            haveShipPart = false;
            GameObject Five = Instantiate(fivePrefab, firePosition.position, firePosition.rotation);
        }
        else if (have6 && Input.GetKeyDown("e") && canDrop)
        {
            have6 = false;
            haveShipPart = false;
            GameObject Six = Instantiate(sixPrefab, firePosition.position, firePosition.rotation);
        }
        else if (have7 && Input.GetKeyDown("e") && canDrop)
        {
            have7 = false;
            haveShipPart = false;
            GameObject Seven = Instantiate(sevenPrefab, firePosition.position, firePosition.rotation);
        }
        else if (have8 && Input.GetKeyDown("e") && canDrop)
        {
            have8 = false;
            haveShipPart = false;
            GameObject Eight = Instantiate(heightPrefab, firePosition.position, firePosition.rotation);
        }
    }
}
