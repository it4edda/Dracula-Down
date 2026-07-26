using Unity.Mathematics;
using UnityEngine;

public class BoomEnemy : EnemyLife
{
    [SerializeField] private GameObject explosion;
    public override void Die()
    {
        Instantiate(explosion, transform.position, quaternion.identity);
        base.Die();
        
    }
}
