using UnityEngine;

public class BackButton : MonoBehaviour
{
    public Animator menuAnimator;

    private void Start()
    {
        if (menuAnimator != null)
        {
            menuAnimator.SetBool("IsBackToMenuPressed", false);
        }
    }

    public void PlayBackAnimation()
    {
        if (menuAnimator != null)
        {
            menuAnimator.SetBool("IsBackToMenuPressed", true);
            menuAnimator.SetBool("IsSettingsPressed", false);
            menuAnimator.SetBool("IsPlayPressed", false);
        }
    }
}
