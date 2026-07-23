using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private bool compressionValue = false;
    public void OnCompression()
    {
        compressionValue = true;
    }

    public void OnRelease()
    {
        compressionValue = false;
    }
    
    //Let the player "compress" and "release"
    
    //at the start of the game, use the ground animator to "send away the ship" 
    //dont let player control themself for a few secs
    //let the stars start falling, 
    //give control to the player
}
