using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenDisplay : MonoBehaviour
{
    public void setOxygen(float currentOxygen, float maxOxygen)
    {
        currentOxygen = currentOxygen / maxOxygen;
        transform.localScale = new Vector2(currentOxygen, 1f);
        if (currentOxygen <= 0)
        {
            transform.localScale = new Vector2(0f, 1f);
        }
        if (currentOxygen >= 1)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    } 
}
