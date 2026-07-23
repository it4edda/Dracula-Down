using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float timeUntilBoost;
    [SerializeField] InputActionReference mouse;
    [SerializeField] bool autoBoost;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (autoBoost)
        {
            StartCoroutine(BoostCooldown());
        }
    }

    void Update()
    {
        
        Vector3 mousePos = Mouse.current.position.ReadValue();   
        mousePos.z=Camera.main.nearClipPlane;
        Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
        float angle = Mathf.Atan2(Worldpos.y - transform.position.y, Worldpos.x - transform.position.x) * Mathf.Rad2Deg;
        quaternion rotation = Quaternion.Euler(0f, 0f, angle -90f);
        transform.rotation = rotation;
        //transform.LookAt(action.action.ReadValue<Vector2>());
        Debug.DrawLine(transform.position, Worldpos, Color.red);
    }

    IEnumerator BoostCooldown()
    {
        yield return new WaitForSeconds(timeUntilBoost);
        Boost();
        StartCoroutine(BoostCooldown());
    }

    public void Boost()
    {
        rb.AddForce(transform.up * speed);
    }
}
