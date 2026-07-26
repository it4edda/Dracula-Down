using System;
using TMPro;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int life;
    public bool isAlive = true;
    [SerializeField]private SceneLoader sceneLoader;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private AudioClip collisionSound;
    [SerializeField] private AudioSource source;

    private void Start()
    {
        hpText.text = life.ToString();
    }

    public void DamagePlayer(int damage)
    {
        life -= damage;
        hpText.text = life.ToString();
        source.PlayOneShot(collisionSound);
        if (life <= 0)
        {
            
            isAlive = false;
            //Debug.Log("I AM DEADDD");
            sceneLoader.ChangeScene("FAILure");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isAlive) return;
        source.PlayOneShot(collisionSound);
        //Debug.Log("COLLISION DETECTED");
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
