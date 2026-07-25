using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip transitionIn;
    [SerializeField] private AudioClip transitionOut;

    [SerializeField] private Animator quit;
    private string savedName;
    private bool hasBeenClicked = false;
    private void Start()
    {
        transition.SetTrigger("In");
        source.PlayOneShot(transitionIn, 0.2f);
    }

    public void ChangeScene(string nextScene)
    {
        if (hasBeenClicked) return;
        hasBeenClicked = true;
        savedName = nextScene;
        transition.SetTrigger("Out");
        source.PlayOneShot(transitionOut, 0.2f);
    }

    public void ChangeSceneForAnimator()
    {
        SceneManager.LoadScene(savedName);
        hasBeenClicked = false;
    }
    public void QuitGame()
    {
        Debug.Log("I QUIT"); 
        Application.Quit();
    }
}
