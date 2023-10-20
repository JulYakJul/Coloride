using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public Animator menuAnimator;

    private void Start()
    {
        if (menuAnimator != null)
        {
            menuAnimator.SetBool("IsSettingsPressed", false);
        }
    }

    public void PlaySettingsAnimation()
    {
        if (menuAnimator != null)
        {
            menuAnimator.SetBool("IsSettingsPressed", true);
        }
    }
}
