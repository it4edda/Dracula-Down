using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;

    public void DamagePlayer(int damage)
    {
        life -= damage;
        if (life <= 0) Debug.Log("I AM DEADDD");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COLLISION DETECTED");
        if (other.gameObject.layer != 9)
        {
            CollisionConsequences();
            
        }
        else return;
    }

    void CollisionConsequences()
    {
        DamagePlayer(1);
    }
    
}
