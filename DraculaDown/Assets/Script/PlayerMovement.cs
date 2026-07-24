using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float initialSpeed;
    [SerializeField] float speedLoss;
    [SerializeField] float timeUntilBoost;
    [SerializeField] InputActionReference mouse;
    [SerializeField] bool autoBoost;
    public bool playerMayMove = false;
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
        Debug.DrawLine(transform.position, Worldpos, Color.red);
    }

    IEnumerator BoostCooldown()
    {
        yield return new WaitForSeconds(timeUntilBoost);
        StopCoroutine(ControlableBoost());
        StartCoroutine(ControlableBoost());
        //Boost();
        if (autoBoost)
            StartCoroutine(BoostCooldown());
    }

    public void Boost()
    {
        //if (playerMayMove) 
        StopCoroutine(ControlableBoost());
        StartCoroutine(ControlableBoost());
            //rb.AddForce(transform.up * speed,  ForceMode2D.Impulse);
    }
    
    IEnumerator ControlableBoost()
    {
        var boostTime = timeUntilBoost;
        var currentSpeed = speed;
        rb.AddForce(transform.up * (initialSpeed * Time.deltaTime),  ForceMode2D.Impulse);
        while (boostTime > 0f)
        {
            rb.AddForce(transform.up * (currentSpeed * Time.deltaTime),  ForceMode2D.Force);
            //rb.linearVelocity = transform.up * currentSpeed;
            
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, speedLoss * Time.deltaTime);
            boostTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
