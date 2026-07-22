using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] float reload = 1f;
    private bool canShoot = true;
    public void OnAttack()
    {
        if (!canShoot) return;
        Debug.Log("DID SHOOT BY PRESSING JUMOP BUTTON");
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        StartCoroutine(ShootTimer());
    }
    IEnumerator ShootTimer()
    {
        canShoot = false;
        yield return new WaitForSeconds(reload);
        canShoot = true;
    }
}
