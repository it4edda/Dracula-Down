using UnityEngine;

public class AnimationEventX : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    public void TransitionEvent()
    {
        sceneLoader.ChangeSceneForAnimator();
    }
}
