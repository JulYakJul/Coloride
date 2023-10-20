using UnityEngine;
using UnityEngine.UI;

public class GameManagerModeTone : MonoBehaviour
{
    public Transform targetCircle;
    public SquareSelectionButtonModeTone[] optionSquares;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreGameOverText;

    public ColorSelectionTimerModeTone colorSelectionTimer;

    public int score = 0;
    public bool gameOver = false;

    public float levelColor = 1f;

    private int numberOfOptions = 6;
    private Color initialTargetColor;

    private float hue;

    void Start()
    {
        initialTargetColor = GenerateRandomColor();
        targetCircle.GetComponent<Renderer>().material.color = initialTargetColor;

        hue = Random.Range(0f, 1f);

        Color[] initialSquareColors = GenerateGradientColors(optionSquares.Length, hue, numberOfOptions);

        for (int i = 0; i < optionSquares.Length; i++)
        {
            if (i < numberOfOptions)
            {
                optionSquares[i].gameObject.SetActive(true);
                optionSquares[i].SetSquareColor(initialSquareColors[i]);
            }
            else
            {
                optionSquares[i].gameObject.SetActive(false);
            }
        }

        UpdateGame();
    }

    public void UpdateGame()
    {
        if (score > 0)
        {
            levelColor = Mathf.Max(0.05f, levelColor - 0.009f);
        }

        Color targetColor = GenerateRandomColor();
        targetCircle.GetComponent<Renderer>().material.color = targetColor;

        hue = (hue + 0.2f) % 1f; 

        Color[] squareColors = GenerateGradientColors(optionSquares.Length, hue, numberOfOptions);

        for (int i = 0; i < optionSquares.Length; i++)
        {
            if (i < numberOfOptions)
            {
                optionSquares[i].gameObject.SetActive(true);
                optionSquares[i].SetSquareColor(squareColors[i]);
            }
            else
            {
                optionSquares[i].gameObject.SetActive(false);
            }
        }

        int correctIndex = Random.Range(0, numberOfOptions);

        optionSquares[correctIndex].SetSquareColor(targetColor);
    }

    Color[] GenerateSquareColors(float hue, int count, int numberOfOptions)
    {
        Color[] colors = new Color[count];

        for (int i = 0; i < count; i++)
        {
            float saturation = 1f;
            float value = (float)(i + 1) / (float)(numberOfOptions);

            colors[i] = Color.HSVToRGB(hue, saturation, value);
        }

        return colors;
    }

    Color[] GenerateGradientColors(int count, float hue, int numberOfOptions)
    {
        Color[] colors = new Color[count];

        for (int i = 0; i < count; i++)
        {
            float saturation = 1f; 
            float value = (float)(i + 1) / (float)(numberOfOptions);

            colors[i] = Color.HSVToRGB(hue, saturation, value);
        }

        return colors;
    }

    public void IncreaseScore()
    {
        score++;
        colorSelectionTimer.ResetTimer();
        UpdateGame();
        UpdateScoreText();

        if (score == 10)
        {
            numberOfOptions = 4;
        }
        else if (score == 20)
        {
            numberOfOptions = 6;
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
            scoreGameOverText.text = score.ToString();
        }
    }

    Color GenerateRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }

    public void GameOver()
    {
        levelColor = Mathf.Max(0.05f, levelColor + 0.01f);
    }
}
