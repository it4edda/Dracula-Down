using System;
using UnityEngine;
using UnityEngine.UI;

public class ProgMeter : MonoBehaviour
{
    [SerializeField] private Slider prog;
    [SerializeField] private Animator instancePopup;
    [SerializeField] private int[] instances;
    private int instancesCompleted;
    private float timer;
    private bool isInInstance = false;

    private void Start()
    {
        prog.maxValue = 1000;
        prog.value = 0;
    }

    private void Update()
    {
        //Debug.Log(timer);
        
        isInInstance = instances[instancesCompleted] < timer;
        
        if (!isInInstance) normalCounter();
    }

    void normalCounter()
    {
        timer += Time.deltaTime;
        prog.value = timer;
    }

    public void LeaveInstance()
    {
        isInInstance = false;
        instancesCompleted++;
    }
    
    //Prog is constantly increasing
    //at 5 intervals, instance starts /////BIG POPUP
    //if in instance, prog waits,
    //in instance, a boss or obstacle appears
    //clear obstacle and prog continues
}
