﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesSpawning : MonoBehaviour
{

    [SerializeField] Transform[] SpawnPositions = new Transform[10];
    int spawnIndex;

    [SerializeField] int ennemiToSpawn = 0;
    int ennemiNumber;
   //int currentWave = 0;
    [SerializeField] float waitTimer = 0;
    float waitTime = 0;
    [SerializeField] GameObject prefabEnnemi;
    //[SerializeField] Transform ennemiSpawnPoint;
    Vector3 spawnPosition;
   // [SerializeField] WaveDisplayer waveDisplayer;
    bool allDead = false;

    Transform player;
    bool canSpawn = true;

    [SerializeField] GameObject oxygenBubblePrefab;
    [SerializeField] GameObject shootingEnemyPrefab;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }
    enum State
    {
        NOT_SPAWNING,
        SPAWN_ENNEMIS,
        WAIT_TO_SPAWN
       
    }
    State state = State.NOT_SPAWNING;
    void Update()
    {
        switch (state)
        {
            case State.NOT_SPAWNING:
                if(canSpawn)
                {
                state = State.SPAWN_ENNEMIS;
                }
                break;
            case State.SPAWN_ENNEMIS:
                int randomNumber;
                randomNumber = Random.Range(0, 3);
               // Debug.Log(randomNumber);
                ChoseSpawnPoint();

                if (randomNumber == 2)
                {
                    GameObject ennemi2 = Instantiate(shootingEnemyPrefab, SpawnPositions[spawnIndex].position, Quaternion.identity);
                }
                else
                {
                    GameObject ennemi = Instantiate(prefabEnnemi, SpawnPositions[spawnIndex].position, Quaternion.identity);
                }
                
                state = State.WAIT_TO_SPAWN;
                break;
            case State.WAIT_TO_SPAWN:
               
                    waitTime -= Time.deltaTime;
                    if (waitTime <= 0)
                    {
                        waitTime = waitTimer;
                        state = State.SPAWN_ENNEMIS;
                    }
                
                break;
        }
    }

    void spawnAttributor()
    {
       // spawnPosition = new Vector3(Random.Range(player.position.x + 10, 7.6f), Random.Range(-4.0f, 4.4f), 0);
        //Random.;
       // spawnPosition = new Vector3(Random.value - 0.5f, 0, Random.value - 0.5f).normalized * Random.Range(20, 50);
        spawnPosition = Random.onUnitSphere * Random.Range(0,10);
        
    }

    void ChoseSpawnPoint()
    {
        spawnIndex = Random.Range(0, SpawnPositions.Length);
    }

  public void SpawnOxygen(Vector2 deathPosition)
    {
        //Debug.Log("oxygen");
        int bubbleNumber;
        bubbleNumber = Random.Range(1, 6);

        for (int i = 0; i <= bubbleNumber; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(deathPosition.x + 2, deathPosition.x - 2), Random.Range(deathPosition.y + 2, deathPosition.y - 2));
          // randomPosition += deathPosition;
            GameObject oxygenBubble = Instantiate(oxygenBubblePrefab, randomPosition, Quaternion.identity);
           // oxygenBubble.transform.position = Random.insideUnitCircle * 2;
        }
    }
}
