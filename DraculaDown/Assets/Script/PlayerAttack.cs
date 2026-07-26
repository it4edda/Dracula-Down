using System;
using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float reload = 1f;
    [SerializeField] private GameObject lazer;
    public bool canShoot = false;
    bool miniCanShoot;

    void OnEnable()
    {
        GameHandler.GameStarted += StartGame;
    }

    void OnDisable()
    {
        GameHandler.GameStarted -= StartGame;
    }

    void StartGame()
    {
         miniCanShoot = true;
    }

    public void OnAttack()
    {
        if (!canShoot && !miniCanShoot) return;
        Debug.Log("Attacked");
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        StartCoroutine(ShootTimer());
    }
    IEnumerator ShootTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(reload);
        canShoot = true;
    }

    public void LazerToggle()
    {
        if (miniCanShoot) lazer.SetActive(!lazer.activeSelf);
    }

    public void ShoopDaWhoop() => StartCoroutine(DoLazer());
    private IEnumerator DoLazer()
    {
        LazerToggle();
        yield return new WaitForSeconds(3);
        LazerToggle();
    }
    
}
