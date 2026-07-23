using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator transition;
    [SerializeField] private Animator quit;
    private string savedName;
    private bool hasBeenClicked = false;
    private void Start()
    {
        transition.SetTrigger("In");
    }

    public void ChangeScene(string nextScene)
    {
        if (hasBeenClicked) return;
        hasBeenClicked = true;
        savedName = nextScene;
        transition.SetTrigger("Out");
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
