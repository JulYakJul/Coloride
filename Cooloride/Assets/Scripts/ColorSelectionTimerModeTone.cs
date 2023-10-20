using UnityEngine;
using UnityEngine.UI;

public class ColorSelectionTimerModeTone : MonoBehaviour
{
    public Slider timerSlider;
    public GameManagerModeTone gameManager; 
    public Animator gameOverAnimator; 
    public float maxTime = 30.0f; 
    public float minTime = 9.0f;

    private float currentTime;
    private float maxTimerValue;

    private void Start()
    {
        maxTimerValue = maxTime;
        currentTime = maxTimerValue;
        timerSlider.maxValue = maxTimerValue;
        timerSlider.value = currentTime;
    }

    private void Update()
    {
        if (!gameManager.gameOver)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                gameManager.GameOver();
                
                if (gameOverAnimator != null)
                {
                    gameOverAnimator.SetBool("IsGameOver", true);
                }
            }

            timerSlider.value = currentTime;
        }
    }

    public void ResetTimer()
    {
        maxTimerValue = Mathf.Lerp(maxTime, minTime, (float)gameManager.score / 50);
        currentTime = maxTimerValue; 
        timerSlider.maxValue = maxTimerValue;
        timerSlider.value = currentTime;
    }
}
