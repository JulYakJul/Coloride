using UnityEngine;
using UnityEngine.UI;

public class ChangeSpriteRendererColor : MonoBehaviour
{
    public float colorChangeSpeed = 1.0f; // The speed of color change
    public Color[] targetColors; // Array of colors

    private SpriteRenderer spriteRenderer;
    private Color currentColor;
    private int targetColorIndex = 0;
    private float t = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
    }

    private void Update()
    {
        spriteRenderer.color = Color.Lerp(currentColor, targetColors[targetColorIndex], t);
        t += colorChangeSpeed * Time.deltaTime;

        if (t >= 1.0f)
        {
            t = 0;
            currentColor = spriteRenderer.color;
            targetColorIndex = (targetColorIndex + 1) % targetColors.Length;
        }
    }
}
