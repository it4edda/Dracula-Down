using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    public bool isAlive = true;
    [SerializeField]private SceneLoader sceneLoader;
    
    public void DamagePlayer(int damage)
    {
        life -= damage;
        if (life <= 0)
        {
            isAlive = false;
            Debug.Log("I AM DEADDD");
            sceneLoader.ChangeScene("FAILure");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isAlive) return;
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
