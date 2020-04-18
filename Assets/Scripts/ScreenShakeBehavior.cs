using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeBehavior : MonoBehaviour
{
    Transform player;
    private float screenShakeTime = 0f;
    private float screenShakeMagnitude = 0.1f;
    private float fadingSpeed = 1.0f;

    private float initialScreenShakeTime = 0f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
        player = FindObjectOfType<PlayerController>().transform;
    }
    
    void Update()
    {
        transform.position = player.position;

        if(screenShakeTime > 0f)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * screenShakeMagnitude * (screenShakeTime / initialScreenShakeTime);

            screenShakeTime -= Time.deltaTime * fadingSpeed;
        }
        else
        {
            screenShakeTime = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float time)
    {
        screenShakeTime = time;
        initialScreenShakeTime = time;
    }
}
