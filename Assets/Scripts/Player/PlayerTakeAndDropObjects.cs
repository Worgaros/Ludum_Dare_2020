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
    TargetIndicator targetIndicator;
    
    Animator anim;

    void Start()
    {
        shooting = FindObjectOfType<Shooting>();
        targetIndicator = FindObjectOfType<TargetIndicator>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("1") && !haveShipPart)
            canPick1 = true;
        else if (other.CompareTag("2") && !haveShipPart)
            canPick2 = true;
        else if (other.CompareTag("3") && !haveShipPart)
            canPick3 = true;
        else if (other.CompareTag("4") && !haveShipPart)
            canPick4 = true;
        else if (other.CompareTag("5") && !haveShipPart)
            canPick5 = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("1"))
            canPick1 = false;
        else if (other.CompareTag("2"))
            canPick2 = false;
        else if (other.CompareTag("3"))
            canPick3 = false;
        else if (other.CompareTag("4"))
            canPick4 = false;
        else if (other.CompareTag("5"))
            canPick5 = false;
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
            GameObject One = Instantiate(onePrefab, firePosition.position, onePrefab.transform.rotation);
            shooting.UnblockShootTakeParts();
            targetIndicator.DesactivateIndicator();
            anim.SetBool("holdingEngrenage", false);
        }
        else if (have2 && Input.GetKeyDown("e") && canDrop)
        {
            have2 = false;
            haveShipPart = false;
            GameObject Two = Instantiate(twoPrefab, firePosition.position, twoPrefab.transform.rotation);
            shooting.UnblockShootTakeParts();
            targetIndicator.DesactivateIndicator();
            anim.SetBool("holdingEcrou", false);
        }
        else if (have3 && Input.GetKeyDown("e") && canDrop)
        {
            have3 = false;
            haveShipPart = false;
            GameObject Three = Instantiate(threePrefab, firePosition.position, threePrefab.transform.rotation);
            shooting.UnblockShootTakeParts();
            targetIndicator.DesactivateIndicator();
            anim.SetBool("holdingMarteau", false);
        }
        else if (have4 && Input.GetKeyDown("e") && canDrop)
        {
            have4 = false;
            haveShipPart = false;
            GameObject Four = Instantiate(fourPrefab, firePosition.position, fourPrefab.transform.rotation);
            shooting.UnblockShootTakeParts();
            targetIndicator.DesactivateIndicator();
            anim.SetBool("holdingCle", false);
        }
        else if (have5 && Input.GetKeyDown("e") && canDrop)
        {
            have5 = false;
            haveShipPart = false;
            GameObject Five = Instantiate(fivePrefab, firePosition.position, fivePrefab.transform.rotation);
            shooting.UnblockShootTakeParts();
            targetIndicator.DesactivateIndicator();
            anim.SetBool("holdingPlaque", false);
        }
        
        //Pick
        if (Input.GetKeyDown("e") && canPick1)
        {
            GameObject one = GameObject.FindGameObjectWithTag("1");
            Destroy(one);
            have1 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShootTakeParts();
            canPick1 = false;
            targetIndicator.ActivateIndicator();
            anim.SetBool("holdingEngrenage", true);
        }
        else if (Input.GetKeyDown("e") && canPick2)
        {
            GameObject two = GameObject.FindGameObjectWithTag("2");
            Destroy(two);
            have2 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShootTakeParts();
            canPick2 = false;
            targetIndicator.ActivateIndicator();
            anim.SetBool("holdingEcrou", true);
        }
        else if (Input.GetKeyDown("e") && canPick3)
        {
            GameObject three = GameObject.FindGameObjectWithTag("3");
            Destroy(three);
            have3 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShootTakeParts();
            canPick3 = false;
            targetIndicator.ActivateIndicator();
            anim.SetBool("holdingMarteau", true);
        }
        else if (Input.GetKeyDown("e") && canPick4)
        {
            GameObject four = GameObject.FindGameObjectWithTag("4");
            Destroy(four);
            have4 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShootTakeParts();
            canPick4 = false;
            targetIndicator.ActivateIndicator();
            anim.SetBool("holdingCle", true);
        }
        else if (Input.GetKeyDown("e") && canPick5)
        {
            GameObject five = GameObject.FindGameObjectWithTag("5");
            Destroy(five);
            have5 = true;
            haveShipPart = true;
            canDrop = false;
            shooting.BlockShootTakeParts();
            canPick5 = false;
            targetIndicator.ActivateIndicator();
            anim.SetBool("holdingPlaque", true);
        }
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
            shooting.UnblockShootTakeParts();
        }
    }

    public void blockDrop()
    {
        canDrop = false;
    }

    public void StopTakeAnim()
    {
        anim.SetBool("holdingEngrenage", false);
        anim.SetBool("holdingEcrou", false);
        anim.SetBool("holdingMarteau", false);
        anim.SetBool("holdingCle", false);
        anim.SetBool("holdingPlaque", false);
    }
}

