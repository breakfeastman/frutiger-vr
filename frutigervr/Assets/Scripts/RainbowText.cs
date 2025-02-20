using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    [Header("Script made by ETHRNL")]
    [Header("If it is possible give credits")]
    public float colorChangeSpeed = 0.1f;

    private TextMeshPro textMeshPro;
    private float hueValue = 0.0f;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();

        if (textMeshPro == null)
            textMeshPro = GetComponentInChildren<TextMeshPro>();

        if (textMeshPro == null)
            Debug.LogError("TextMeshPro component not found on the GameObject or its children.");
    }

    void Update()
    {
        if (textMeshPro == null)
            return;

        hueValue += colorChangeSpeed * Time.deltaTime;

        if (hueValue >= 1.0f)
            hueValue -= 1.0f;

        Color newColor = Color.HSVToRGB(hueValue, 1.0f, 1.0f);
        textMeshPro.color = newColor;
    }
}