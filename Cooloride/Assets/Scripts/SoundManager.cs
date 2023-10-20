using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private bool isSoundOn = true;

    public TMPro.TextMeshProUGUI soundText; 

    private void Start()
    {
        UpdateSoundText(); 
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        AudioListener.pause = !isSoundOn;
        UpdateSoundText();
    }

    private void UpdateSoundText()
    {
        if (soundText != null)
        {
            soundText.text = isSoundOn ? "On" : "Off";
        }
    }
}
