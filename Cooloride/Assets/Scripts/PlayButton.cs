using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Animator menuAnimator;

    public void LoadGameScene()
    {
        if (menuAnimator != null)
        {
            menuAnimator.SetBool("IsPlayPressed", false);
        }
    }

    public void PlayAnimation()
    {
        if (menuAnimator != null)
        {
            menuAnimator.SetBool("IsBackToMenuPressed", false);
            menuAnimator.SetBool("IsPlayPressed", true);
        }
    }
}
