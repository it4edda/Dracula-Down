using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float initialSpeed;
    [SerializeField] float speedLoss;
    [SerializeField] float timeUntilBoost;
    [SerializeField] InputActionReference mouse;
    [SerializeField] bool autoBoost;
    [SerializeField] private Slider boostOMeter;
    [SerializeField] private float boostOMeterValue;
    [SerializeField] private Image countDown;
    [SerializeField] private Sprite[] countDownNumbers;
    [SerializeField] private ParticleSystem burstParticle;
    [SerializeField] private ParticleSystem postBurstParticle;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private AudioClip boostSound;
    [SerializeField] private GameObject AOE;
    
    public bool playerMayMove = false;
    Rigidbody2D rb;
    void Start()
    {
        boostOMeter.maxValue = timeUntilBoost;
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        GameHandler.GameStarted += GameStart;
    }

    void OnDisable()
    {
        GameHandler.GameStarted -= GameStart;
    }

    void GameStart()
    {
        playerMayMove = true;
        if (autoBoost)
        {
            StartCoroutine(BoostCooldown());
        }
    }

    void Update()
    {
        if(!playerMayMove) return;
        
        Vector3 mousePos = Mouse.current.position.ReadValue();   
        mousePos.z=Camera.main.nearClipPlane;
        Vector3 Worldpos=Camera.main.ScreenToWorldPoint(mousePos);
        float angle = Mathf.Atan2(Worldpos.y - transform.position.y, Worldpos.x - transform.position.x) * Mathf.Rad2Deg;
        quaternion rotation = Quaternion.Euler(0f, 0f, angle -90f);
        transform.rotation = rotation;
        Debug.DrawLine(transform.position, Worldpos, Color.red);

        boostOMeterValue += Time.deltaTime;
        boostOMeter.value = boostOMeterValue;
        
        switch (Mathf.RoundToInt(timeUntilBoost-boostOMeterValue + 0.5f))
        {
            case 3:
                countDown.sprite = countDownNumbers[0];
                break;
            case 2:
                countDown.sprite = countDownNumbers[1];
                break;
            case 1:
                countDown.sprite = countDownNumbers[2];
                break;
            
            
            default: // Transparent
                countDown.sprite = countDownNumbers[3];
                break;
        }
    }

    IEnumerator BoostCooldown()
    {
        yield return new WaitForSeconds(timeUntilBoost);
        if (playerMayMove)
        {
            StopCoroutine(ControlableBoost());
            StartCoroutine(ControlableBoost());
        }
        //Boost();
        if (autoBoost)
        {
            StartCoroutine(BoostCooldown());
            BurstParticles();
            boostOMeterValue = 0;
        }
            
    }

    public void Boost()
    {
        if (!playerMayMove) return;
        StopCoroutine(ControlableBoost());
        StartCoroutine(ControlableBoost());
            //rb.AddForce(transform.up * speed,  ForceMode2D.Impulse);
            BurstParticles();
    }
    
    IEnumerator ControlableBoost()
    {
        var boostTime = timeUntilBoost;
        var currentSpeed = speed;
        rb.AddForce(transform.up * (initialSpeed * Time.deltaTime),  ForceMode2D.Impulse);
        StartCoroutine(aoeActivation());
        
        while (boostTime > 0f)
        {
            rb.AddForce(transform.up * (currentSpeed * Time.deltaTime),  ForceMode2D.Force);
            //rb.linearVelocity = transform.up * currentSpeed;
            //
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, speedLoss * Time.deltaTime);
            boostTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator aoeActivation()
    {
        AOE.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        AOE.SetActive(false);
    }

    void BurstParticles()
    {
        burstParticle.Play();
        postBurstParticle.Play();
        audioPlayer.PlayOneShot(boostSound, 0.2f);
    }   
}
