using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] float lifetime;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject boom;
    private Coroutine myTimer;
    [SerializeField] private int myDamage = 1;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myTimer = StartCoroutine(Suicide());
        //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyLife>().TakeDamage(myDamage);
        Instantiate(boom, transform.position, quaternion.identity);
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
