using System;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private AudioPlayer audioSource;
    [SerializeField] private AudioClip boomSound;
    [SerializeField] private int hitPoints = 1;

    private void Start()
    {
        audioSource = FindAnyObjectByType<AudioPlayer>();
    }

    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0) Die();
    }

    private void Die()
    {
        audioSource.PlaySimpleSound(boomSound, 0.1f);
        Destroy(gameObject);
    }
}
