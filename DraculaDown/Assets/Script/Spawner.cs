using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnables = new List<GameObject>();
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRadius;
public bool canSpawnEnemies = false;

void OnEnable()
{
    GameHandler.GameStarted += StartGame;
}

void OnDisable()
{
    GameHandler.GameStarted -= StartGame;
}

void StartGame()
{
    canSpawnEnemies = true;
    StartCoroutine(SpawnTimer());
}

IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnRate);
        Spawn();
    }

    void Spawn()
    {
        if (!canSpawnEnemies) return;
        float   randomAngle   = Random.Range(0f, 2f * Mathf.PI);
        Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(randomAngle) * spawnRadius, Mathf.Sin(randomAngle) * spawnRadius, 0f);
        Instantiate(spawnables[Random.Range(0, spawnables.Count)], spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnTimer());
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
