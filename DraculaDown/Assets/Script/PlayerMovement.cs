using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Boost()
    {
        rb.AddForce(Vector2.up * speed);
        //rb.linearVelocity = Vector2.up * speed;
    }

    public void LookAround()
    {
        
    }
}
