using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;

    public void DamagePlayer(int damage)
    {
        life -= damage;
        if (life <= 0) Debug.Log("I AM DEADDD");
    }
}
