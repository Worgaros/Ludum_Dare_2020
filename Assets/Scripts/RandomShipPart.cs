using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShipPart : MonoBehaviour
{
    bool start = true;

    [SerializeField] Transform initialPoint;

    [SerializeField] Transform spawn1;
    [SerializeField] Transform spawn2;
    [SerializeField] Transform spawn3;
    [SerializeField] Transform spawn4;

    private void Start()
    {
        transform.position = initialPoint.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
    private void Update()
    {

        if (start)
        {
            ShipPart();
            start = false;
        }
    }

    void ShipPart()
    {
        int randomNmb;
        randomNmb = Random.Range(0, 4);

        if (randomNmb == 1)
        {
            transform.position = spawn1.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (randomNmb == 2)
        {
            transform.position = spawn2.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        }
        if (randomNmb == 3)
        {
            transform.position = spawn3.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        }
        if (randomNmb == 4)
        {
            transform.position = spawn4.transform.position;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        }

    }

}
