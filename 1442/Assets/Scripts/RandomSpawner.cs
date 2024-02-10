using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public double spawnInterval = 1.0;
    public double currentTime = 0.0;
    public double lastSpawnTime = 0.0;

    void Update()
    {
        currentTime = Time.timeAsDouble;
        if (currentTime - lastSpawnTime > spawnInterval)
        {
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            lastSpawnTime = currentTime;
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        }
    }
}
