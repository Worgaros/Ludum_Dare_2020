﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject indicator;

    private void Start()
    {
        indicator.SetActive(false);
    }

    void Update()
    {
        var direction = target.position - transform.position;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void ActivateIndicator()
    { 
        indicator.SetActive(true);
    }

    public void DesactivateIndicator()
    {
        indicator.SetActive(true);
    }
}