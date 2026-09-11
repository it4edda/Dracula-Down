using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;
    [SerializeField] protected float agroRadius;
    [SerializeField] private float rubberbandingRadius = 8; //The distance to the player for enemy to start speeding up
    
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

        float localSpeed = speed;
        if (Vector2.Distance(target.position, transform.position) > rubberbandingRadius) localSpeed = speed * 2;
            
        
        rb.linearVelocity = transform.up * (localSpeed * Time.deltaTime);
        
        //TODO The farther away the player is, the enemy should move faster,
        //TODO See mario kart rubberbanding -mvh ALDIN
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
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, rubberbandingRadius);
    }
}
