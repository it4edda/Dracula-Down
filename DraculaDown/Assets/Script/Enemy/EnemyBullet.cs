using System.Collections;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBullet : EnemyWeapon
{
    [SerializeField] private float force;
    [SerializeField] float lifetime;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject boom;
    private Coroutine myTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTimer = StartCoroutine(Suicide());
        //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (!other.CompareTag("Player")){ return; }
        Instantiate(boom, other.transform.position, quaternion.identity);
        StopCoroutine(myTimer);
        killObj();
    }

    IEnumerator Suicide()
    {
        yield return new WaitForSeconds(lifetime);
        killObj();
    }

    void killObj()
    {
        Destroy(gameObject);
    }
}
