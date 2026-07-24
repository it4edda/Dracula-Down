using System;
using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float reload = 1f;
    [SerializeField] private GameObject lazer;
    public bool canShoot = false;
    public void OnAttack()
    {
        if (!canShoot) return;
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
        if (canShoot)
        lazer.SetActive(!lazer.activeSelf);
    }
    
}
