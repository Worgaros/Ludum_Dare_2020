using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeAndDropObjects : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other);
    }
}
