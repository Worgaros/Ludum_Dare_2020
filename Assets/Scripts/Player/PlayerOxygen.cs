using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{
    float oxygen = 0f;

    // Update is called once per frame
    void Update()
    {
        if ( oxygen <= 0)
        {
            PlayerHealth.TakeDmg();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Oxygen")
        {
            PlayerHealth.TakeHealth();
        }
    }
}
