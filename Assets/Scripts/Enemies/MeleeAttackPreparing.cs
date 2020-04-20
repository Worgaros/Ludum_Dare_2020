using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackPreparing : MonoBehaviour
{

    Rigidbody2D body;
    Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerPosition = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
