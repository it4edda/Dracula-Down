using System.Collections;
using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] float lifetime;
    [SerializeField] private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Suicide());
        //rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
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
