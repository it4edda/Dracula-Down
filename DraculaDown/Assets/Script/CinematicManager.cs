using System.Collections;
using UnityEngine;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SceneLoader sceneLoader;
    private int counter;
    void Start()
    {
        counter = 0;
        StartCoroutine(Cinematic());
    }
    IEnumerator Cinematic()
    {
        counter++;
        yield return new WaitForSeconds(5);
        animator.SetInteger("Next", counter);
        StartCoroutine(Cinematic());
    }

    public void callNewScene()
    {
        sceneLoader.ChangeScene("GameScene");
    }
}