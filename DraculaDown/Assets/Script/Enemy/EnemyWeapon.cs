using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] int damage;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerLife>().DamagePlayer(damage);
        }
    }
}
