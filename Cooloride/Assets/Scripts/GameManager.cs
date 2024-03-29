using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform targetCircle;
    public SquareSelectionButton[] optionSquares;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI scoreGameOverText;

    public ColorSelectionTimer colorSelectionTimer;

    public int score = 0;
    public bool gameOver = false;

    public float levelColor = 1f;

    private int numberOfOptions = 2;

    private Color initialTargetColor;

    void Start()
    {
        initialTargetColor = GenerateRandomColor();
        targetCircle.GetComponent<Renderer>().material.color = initialTargetColor;

        Color[] initialSquareColors = GenerateRandomColors(optionSquares.Length, levelColor);

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

        Color[] squareColors = GenerateSquareColors(targetColor, optionSquares.Length, levelColor);

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

    Color[] GenerateSquareColors(Color targetColor, int count, float currentLevelColor)
    {
        Color[] colors = new Color[count];

        for (int i = 0; i < count; i++)
        {
            colors[i] = GenerateSimilarColor(targetColor, currentLevelColor);
        }

        return colors;
    }

    Color GenerateSimilarColor(Color targetColor, float currentLevelColor)
    {
        float rRange = Mathf.Clamp01(Random.Range(0.0f, currentLevelColor));
        float gRange = Mathf.Clamp01(Random.Range(0.0f, currentLevelColor));
        float bRange = Mathf.Clamp01(Random.Range(0.0f, currentLevelColor));

        float r = Random.Range(targetColor.r - rRange, targetColor.r + rRange);
        float g = Random.Range(targetColor.g - gRange, targetColor.g + gRange);
        float b = Random.Range(targetColor.b - bRange, targetColor.b + bRange);

        r = Mathf.Clamp01(r);
        g = Mathf.Clamp01(g);
        b = Mathf.Clamp01(b);

        return new Color(r, g, b);
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

    Color[] GenerateRandomColors(int count, float currentLevelColor)
    {
        Color[] colors = new Color[count];
        for (int i = 0; i < count; i++)
        {
            colors[i] = GenerateRandomColor();
        }
        return colors;
    }

    public void GameOver()
    {
        levelColor = Mathf.Max(0.05f, levelColor + 0.01f);
    }
}
