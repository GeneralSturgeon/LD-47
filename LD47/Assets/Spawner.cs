using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float timeBetweenSpawns = 2f;
    public float spawnRandomness = 0.5f;
    public int numberInDiffLevel = 10;
    public float timeDecreaseDiffLevel = 0.5f;
    private float timeLeft = 1f;
    private int spawnsInDiff = 0;
    private int diff = 0;
    private int maxDiff = 6;

    public GameObject[] obstacles;
    private void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        if(timeLeft <= 0)
        {
            Spawn();
            timeLeft = timeBetweenSpawns + Random.Range(-spawnRandomness, spawnRandomness);
        }

    }

    private void Spawn()
    {
        spawnsInDiff++;

        if(spawnsInDiff >= numberInDiffLevel)
        {
            diff++;
            timeBetweenSpawns -= timeDecreaseDiffLevel;

            if(diff >= maxDiff)
            {
                diff = maxDiff;
            }

            spawnsInDiff = 0; 
        }

        switch(diff)
        {
            case (0):
                
                Instantiate(obstacles[Random.Range(0, 5)], transform.position, Quaternion.identity);
                break;

            case (1):
                Instantiate(obstacles[Random.Range(0, 5)], transform.position + new Vector3(0, Random.Range(-3f, 3f), 0), Quaternion.identity);
                break;

            case (2):
                Instantiate(obstacles[Random.Range(0, 7)], transform.position + new Vector3(0, Random.Range(-5f, 5f), 0), Quaternion.identity);
                break;

            case (3):
                Instantiate(obstacles[Random.Range(0, 8)], transform.position + new Vector3(0, Random.Range(-5f, 5f), 0), Quaternion.identity);
                break;

            case (4):
                Instantiate(obstacles[Random.Range(0, 9)], transform.position + new Vector3(0, Random.Range(-5f, 5f), 0), Quaternion.identity);
                break;

            case (5):
                Instantiate(obstacles[Random.Range(0, 10)], transform.position + new Vector3(0, Random.Range(-5f, 5f), 0), Quaternion.identity);
                break;

            case (6):
                Instantiate(obstacles[Random.Range(0, 12)], transform.position + new Vector3(0, Random.Range(-5f, 5f), 0), Quaternion.identity);
                break;

            default:
                Instantiate(obstacles[Random.Range(0, 12)], transform.position + new Vector3(0, Random.Range(-5f, 5f), 0), Quaternion.identity);
                break;
        }
        
    }
}
