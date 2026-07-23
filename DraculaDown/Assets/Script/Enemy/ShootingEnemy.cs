using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootingEnemy : BaseEnemy
{
    [SerializeField] MinMax moveRadiusBounds;
    [SerializeField] MinMax timeUntilMoveBounds;
    [SerializeField] Vector2 moveTarget;

    bool isWaiting;

    protected override void Start()
    {
        base.Start();
        SetMovementTarget();
    }

    protected override void Movement()
    {
        if(!isMoving){ return; }
        transform.position = Vector2.MoveTowards(transform.position, moveTarget, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, moveTarget) < 0.5f && !isWaiting)
        {
            StartCoroutine(WaitThenMove());
        }
    }

    IEnumerator WaitThenMove()
    {
        isWaiting = true;
        float timeuntilmove = Random.Range(timeUntilMoveBounds.min, timeUntilMoveBounds.max);
        yield return new WaitForSeconds(timeuntilmove);
        SetMovementTarget();
        isWaiting = false;
    }

    void SetMovementTarget()
    {
        Vector2 playerPos = new Vector2(target.position.x, target.position.y);
        moveTarget = RandomPointInAnnulus(playerPos,  moveRadiusBounds.min, moveRadiusBounds.max);
    }

    public Vector2 RandomPointInAnnulus(Vector2 origin, float minRadius, float maxRadius){

        var randomDirection = (Random.insideUnitCircle * origin).normalized;

        var randomDistance = Random.Range(minRadius, maxRadius);

        var point = origin + randomDirection * randomDistance;

        return point;
    }
}
[Serializable]
public struct MinMax
{
    public float min;
    public float max;
}
