using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> spawnables = new List<GameObject>();
    [SerializeField] float spawnRate;
    [SerializeField] float spawnRadius;

    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(spawnRate);
        Spawn();
    }

    void Spawn()
    {
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
