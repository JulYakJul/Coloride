using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool isSoundOn = true;

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        AudioListener.pause = !isSoundOn;
    }
}
