using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    [SerializeField] Transform target;

    static bool indicator = false;

    private void Start()
    {
        indicator = false;
    }

    void Update()
    {
       if (indicator)
        {
            var direction = target.position - transform.position;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void ActivateIndicator()
    {
        indicator = true;
    }

    public void DesactivateIndicator()
    {
        indicator = false;
    }
}
