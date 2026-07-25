using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource player;
    public void PlaySimpleSound(AudioClip clip)
    {
        player.PlayOneShot(clip);
    }
}
