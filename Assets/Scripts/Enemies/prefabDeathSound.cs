using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabDeathSound : MonoBehaviour
{

    [SerializeField] AudioSource DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        DeathSound.Play();
    }

    // Update is called once per frame
    
}
