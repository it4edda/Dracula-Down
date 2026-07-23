using System;
using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float reload = 1f;
    [SerializeField] private GameObject lazer;
    private bool canShoot = true;
    public void OnAttack()
    {
        Debug.Log("Attacked");
        if (!canShoot) return;
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
        lazer.SetActive(!lazer.activeSelf);
    }
    
}
