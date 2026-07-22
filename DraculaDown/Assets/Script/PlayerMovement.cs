using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputActionReference mouse;
    [SerializeField] float speed;
    Rigidbody2D rb;
    Vector2 lookDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Vector3 mousePos = Mouse.current.position.ReadValue();   
        mousePos.z=Camera.main.nearClipPlane;
        Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
        float angle = Mathf.Atan2(Worldpos.y - transform.position.y, Worldpos.x - transform.position.x) * Mathf.Rad2Deg;
        quaternion rotation = Quaternion.Euler(0f, 0f, angle);
        transform.rotation = rotation;
        //transform.LookAt(action.action.ReadValue<Vector2>());
        Debug.DrawLine(transform.position, Worldpos, Color.red);
    }

    public void Boost()
    {
        rb.AddForce(transform.right * speed);
        //rb.linearVelocity = Vector2.up * speed;
    }

    public void LookAround(Vector2 direction)
    {
        lookDir = direction;
    }
}
