using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int hitPoints = 1;
    public void TakeDamage()
    {
        hitPoints--;
        if (hitPoints <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
