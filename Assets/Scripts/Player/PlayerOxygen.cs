using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    [SerializeField] float maxOxygen = 50;
    float currentOxygen;

    OxygenDisplay oxygen;

    private void Start()
    {
        oxygen = FindObjectOfType<OxygenDisplay>();
        currentOxygen = maxOxygen;
    }

    void Update()
    {
        if ( currentOxygen <= 0)
        {
            PlayerHealth.TakeDmg();
        }
        else
        {
            PlayerHealth.TakeHealth();
        }
        
        currentOxygen -= Time.deltaTime;
        Debug.Log("oxygen" + currentOxygen);
        oxygen.setOxygen(currentOxygen, maxOxygen);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("oxygenBubble"))
        {
            Score.GetOxygenPoint();
            currentOxygen += 0.5f;

        }
    }
}
