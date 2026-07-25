using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static event Action GameStarted;
    
    private bool compressionValue = false;
    private bool launchIsFinished = false;
    [SerializeField] private Animator launchAnimator;
    [SerializeField] private float timeTilPlayerMayStart = 5f;
    [SerializeField] private Animator UiAnimator;
    [SerializeField] private Spawner sp;
    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private ParticleSystem launchParticle;
    [SerializeField] private ParticleSystem starParticles;

    private void Update()
    {
        startLaunch();
    }

    void startLaunch()
    {
        launchAnimator.SetBool("Compressing", compressionValue);
        if(launchIsFinished) return;
        //Debug.Log(compressionValue);
        if (Input.GetKey(KeyCode.Space))
        {
            compressionValue = true;
        }
        else if (compressionValue && !Input.GetKey(KeyCode.Space))
        {
            compressionValue = false;
            StartCoroutine(Allowances());
            
            launchParticle.Play();
            launchIsFinished = true;
        }
    }

    IEnumerator Allowances()
    {
        cameraMovement.cameraCanMove = true;
        starParticles.Play();
        yield return new WaitForSeconds(timeTilPlayerMayStart);
        UiAnimator.SetBool("Show",true);
        launchAnimator.gameObject.SetActive(false);
        GameStarted?.Invoke();
    }

    //Let the player "compress" and "release"
    
    //at the start of the game, use the ground animator to "send away the ship" 
    //dont let player control themself for a few secs
    //let the stars start falling, 
    //give control to the player
}
