using UnityEngine;

public class AnimationEventX : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private GameHandler gameHandler;
    public void TransitionEvent()
    {
        sceneLoader.ChangeSceneForAnimator();
    }

    public void IAmFullyPressed()
    {
        gameHandler.iAmFullyPressed = true;
    }
}
