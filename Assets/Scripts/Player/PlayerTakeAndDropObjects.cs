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
    bool canDrop = false;
    bool canPick1 = false;
    bool canPick2 = false;
    bool canPick3 = false;
    bool canPick4 = false;
    bool canPick5 = false;
    
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject onePrefab;
    [SerializeField] GameObject twoPrefab;
    [SerializeField] GameObject threePrefab;
    [SerializeField] GameObject fourPrefab;
    [SerializeField] GameObject fivePrefab;

    Shooting shooting;

    void Start()
    {
        shooting = FindObjectOfType<Shooting>();
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if ()
    // }

    void OnTriggerStay2D(Collider2D other)
    {
        
        //Pick
        if (Input.GetKeyDown("e") && other.CompareTag("1") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have1 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShoot();
            canPick1 = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("2") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have2 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShoot();
            canPick2 = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("3") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have3 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShoot();
            canPick3 = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("4") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have4 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShoot();
            canPick4 = false;
        }
        else if (Input.GetKeyDown("e") && other.CompareTag("5") && !haveShipPart)
        {
            Destroy(other.gameObject);
            have5 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShoot();
            canPick5 = false;
        }
    }

    void Update()
    {
        
        //drop
        if (Input.GetKeyUp("e"))
        {
            canDrop = true;
        }
        if (have1 && Input.GetKeyDown("e") && canDrop)
        {
            have1 = false;
            haveShipPart = false;
            GameObject One = Instantiate(onePrefab, firePosition.position, firePosition.rotation);
            shooting.UnblockShoot();
        }
        else if (have2 && Input.GetKeyDown("e") && canDrop)
        {
            have2 = false;
            haveShipPart = false;
            GameObject Two = Instantiate(twoPrefab, firePosition.position, firePosition.rotation);
            shooting.UnblockShoot();
        }
        else if (have3 && Input.GetKeyDown("e") && canDrop)
        {
            have3 = false;
            haveShipPart = false;
            GameObject Three = Instantiate(threePrefab, firePosition.position, firePosition.rotation);
            shooting.UnblockShoot();
        }
        else if (have4 && Input.GetKeyDown("e") && canDrop)
        {
            have4 = false;
            haveShipPart = false;
            GameObject Four = Instantiate(fourPrefab, firePosition.position, firePosition.rotation);
            shooting.UnblockShoot();
        }
        else if (have5 && Input.GetKeyDown("e") && canDrop)
        {
            have5 = false;
            haveShipPart = false;
            GameObject Five = Instantiate(fivePrefab, firePosition.position, firePosition.rotation);
            shooting.UnblockShoot();
        }
        
        
        // Debug.Log("1" + have1);
        // Debug.Log("2" + have2);
        // Debug.Log("3" + have3);
        // Debug.Log("4" + have4);
        // Debug.Log("5" + have5);
        //
        // Debug.Log(haveShipPart);
    }

    public void removeShipParts()
    {
        if (haveShipPart)
        {
            have1 = false;
            have2 = false;
            have3 = false;
            have4 = false;
            have5 = false;
            haveShipPart = false;
            shooting.UnblockShoot();
        }
    }

    public void blockDrop()
    {
        canDrop = false;
    }
}
