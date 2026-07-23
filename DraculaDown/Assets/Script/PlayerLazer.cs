using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLazer : MonoBehaviour
{
    [SerializeField] private float reverseBoost = 1f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject boom;
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyLife>()?.TakeDamage(1);
        Instantiate(boom, other.transform.position, quaternion.identity);
    }

    private void Update()
    {
        rb.AddForce(-1 * reverseBoost * Time.deltaTime * transform.up);
    }
}
