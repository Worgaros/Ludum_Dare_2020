using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesSpawning : MonoBehaviour
{

    [SerializeField] Transform[] SpawnPositions = new Transform[10];
    int spawnIndex;

    [SerializeField] int ennemiToSpawn = 0;
    int ennemiNumber;
    int currentWave = 0;
    [SerializeField] float waitTimer = 0;
    float waitTime = 0;
    [SerializeField] GameObject prefabEnnemi;
    //[SerializeField] Transform ennemiSpawnPoint;
    Vector3 spawnPosition;
   // [SerializeField] WaveDisplayer waveDisplayer;
    bool allDead = false;

    Transform player;
    bool canSpawn = true;

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

                ChoseSpawnPoint();
                    GameObject ennemi = Instantiate(prefabEnnemi,SpawnPositions[spawnIndex].position, Quaternion.identity);
                    
                
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
}
