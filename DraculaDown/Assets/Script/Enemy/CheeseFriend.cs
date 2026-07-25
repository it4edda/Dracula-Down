using System;
using UnityEngine;

public class CheeseFriend : MonoBehaviour
{
    [SerializeField] bool isBrimstone;
    [SerializeField] private float speed;

    private void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * speed, ForceMode2D.Force );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isBrimstone) other.GetComponent<PlayerAttack>().ShoopDaWhoop();
        else other.GetComponent<PlayerLife>().DamagePlayer(-1); //and play sound
        Destroy(gameObject);
    }
}
