using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    [SerializeField] float maxOxygen = 50;
    float currentOxygen;

    PlayerHealth playerHealth;

    OxygenDisplay oxygen;

    bool takeFromBottle = false;

    private void Start()
    {
        oxygen = FindObjectOfType<OxygenDisplay>();
        currentOxygen = maxOxygen;
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if ( currentOxygen <= 0)
        {
            playerHealth.TakeDmg();
        }
        
        currentOxygen -= Time.deltaTime*0.8f;
       // Debug.Log("oxygen" + currentOxygen);
        oxygen.setOxygen(currentOxygen, maxOxygen);

        TakeOxygenFromBottle();

        if(currentOxygen>=maxOxygen)
        {
            currentOxygen = maxOxygen;
        }
    }
    
     void TakeOxygenFromBottle()
    {
        if (takeFromBottle)
        {
           
                currentOxygen += Time.deltaTime*4;
            
        }
        
    }

    public void ConnectingToBottle()
    {
        takeFromBottle = true;
    }

    public void DisconnectedFromBottle()
    {
        takeFromBottle = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "oxygenBubble")
        {
            Score.GetOxygenPoint();
            currentOxygen += 0.5f;
        }
    }
}
