using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;
    [SerializeField] protected float agroRadius;
    
    protected bool isMoving;
    protected bool isRotating;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetTarget();
        isMoving = true;
        isRotating = true;
    }

    void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        Movement();
        
        RotateToTarget();
    }

    protected virtual void Movement()
    {
        if (!isMoving) { return; }
        
        rb.linearVelocity = transform.up * (speed * Time.deltaTime);
    }

    void RotateToTarget()
    {
        if (!isRotating) { return; }
        
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, angle -90f);
        transform.rotation = rotation;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRadius);
    }
}
