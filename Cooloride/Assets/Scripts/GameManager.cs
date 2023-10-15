using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform targetCircle;
    public SquareSelectionButton[] optionSquares;
    public TMPro.TextMeshProUGUI scoreText;

    public int score = 0;
    public bool gameOver = false;

    public float levelColor = 0.5f; 

    void Start()
    {
        Color targetColor = GenerateRandomColor();
        targetCircle.GetComponent<Renderer>().material.color = targetColor;

        Color[] initialSquareColors = GenerateRandomColors(optionSquares.Length);
        for (int i = 0; i < optionSquares.Length; i++)
        {
            optionSquares[i].SetSquareColor(initialSquareColors[i]);
        }

        UpdateGame();
    }

    public void UpdateGame()
    {
        if (score > 0)
        {
            levelColor = Mathf.Max(0.05f, levelColor - 0.01f);
        }

        Color targetColor = GenerateRandomColor();
        targetCircle.GetComponent<Renderer>().material.color = targetColor;

        Color[] squareColors = GenerateSquareColors(targetColor, optionSquares.Length);

        for (int i = 0; i < optionSquares.Length; i++)
        {
            optionSquares[i].SetSquareColor(squareColors[i]);
        }

        int correctIndex = Random.Range(0, optionSquares.Length);

        optionSquares[correctIndex].SetSquareColor(targetColor);
    }

    public void IncreaseScore()
    {
        score++;
        score++;
        Debug.Log("Верно!");
        UpdateGame();
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    Color[] GenerateSquareColors(Color targetColor, int count)
    {
        Color[] colors = new Color[count];

        for (int i = 0; i < count; i++)
        {
            // Generate a color that is as similar as possible to the color of the circle
            colors[i] = GenerateSimilarColor(targetColor);
        }

        return colors;
    }

    Color GenerateSimilarColor(Color targetColor)
    {
        float rRange = Mathf.Clamp01(Random.Range(0.5f, 1.0f)); 
        float gRange = Mathf.Clamp01(Random.Range(0.5f, 1.0f));
        float bRange = Mathf.Clamp01(Random.Range(0.5f, 1.0f));

        float r = Random.Range(targetColor.r - rRange * levelColor, targetColor.r + rRange * levelColor);
        float g = Random.Range(targetColor.g - gRange * levelColor, targetColor.g + gRange * levelColor);
        float b = Random.Range(targetColor.b - bRange * levelColor, targetColor.b + bRange * levelColor);

        r = Mathf.Clamp01(r);
        g = Mathf.Clamp01(g);
        b = Mathf.Clamp01(b);

        return new Color(r, g, b);
    }

    Color GenerateRandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b);
    }

    Color[] GenerateRandomColors(int count)
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
        Debug.Log("Неверно!");
        levelColor = Mathf.Max(0.05f, levelColor + 0.01f);
    }
}
