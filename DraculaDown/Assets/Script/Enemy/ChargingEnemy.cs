using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ChargingEnemy : BaseEnemy
{
    [SerializeField] float timeUntilCharge;
    [SerializeField] float chargeSpeed;
    [SerializeField] float chargeDuration;
    bool isCharging = false;

    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(transform.position, target.position) <= agroRadius)
        {
            Charge();
        }
        
    }
    
    void Charge()
    {
        if (isCharging) { return; }
        isMoving = false;
        
        StartCoroutine(Charging());
    }

    IEnumerator Charging()
    {
        isCharging = true;
        rb.linearVelocity = Vector3.zero;
        yield return new WaitForSeconds(timeUntilCharge);
        isRotating = false;
        rb.linearVelocity = transform.up * (chargeSpeed * Time.deltaTime);
        yield return new WaitForSeconds(chargeDuration);
        rb.linearVelocity = Vector3.zero;
        isMoving = true;
        isRotating = true;
        isCharging = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, agroRadius);
    }
}
