using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairationBar : MonoBehaviour
{


    public void setRepairTime(float currentRepairTime, float maxRepairTime)
    {
        currentRepairTime = currentRepairTime / maxRepairTime;
        transform.localScale = new Vector2(currentRepairTime, 1f);
        if (currentRepairTime <= 0)
        {
            transform.localScale = new Vector2(0f, 1f);
        }
        if (currentRepairTime >= 1)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
