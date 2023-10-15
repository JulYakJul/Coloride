using UnityEngine;
using UnityEngine.UI;

public class SquareSelectionButton : MonoBehaviour
{
    public GameManager gameManager; 
    private Image image;

    private Button button;
    private bool isClickable = true;

    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        gameManager.UpdateGame();
    }

    public void SetSquareColor(Color color)
    {
        if (image != null) 
        {
            image.color = color;
        }
    }


    private void OnClick()
    {
        if (isClickable)
        {
            // Getting the color of the square from the button at each click
            Color squareColor = image.color;
            Color targetColor = gameManager.targetCircle.GetComponent<Renderer>().material.color;

            if (ColorMatches(squareColor, targetColor))
            {
                gameManager.IncreaseScore();
            }
            else
            {
                gameManager.GameOver();
            }

            gameManager.UpdateGame();

            ResetButton();

            // Color matching check
            Debug.Log("Square Color: " + squareColor);
            Debug.Log("Target Color: " + targetColor);
        }
    }

    private bool ColorMatches(Color colorA, Color colorB)
    {
        float threshold = 0.01f;

        bool redMatches = Mathf.Abs(colorA.r - colorB.r) <= threshold;
        bool greenMatches = Mathf.Abs(colorA.g - colorB.g) <= threshold;
        bool blueMatches = Mathf.Abs(colorA.b - colorB.b) <= threshold;

        return redMatches && greenMatches && blueMatches;
    }

    public void ResetButton()
    {
        isClickable = true;
        button.interactable = true;
    }
}
