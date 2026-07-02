using UnityEngine;
using TMPro;

public class BackgroundProgress : MonoBehaviour
{
    public SpriteRenderer coloredBackground;
    public TMP_Text porcentagemTexto;

    [Range(0f, 1f)]
    public float alphaStep = 0.03f; // 3%

    private float currentAlpha = 0f;

    void Start()
    {
        currentAlpha = 0f;

        SetAlpha(currentAlpha);
        AtualizarTexto();
    }

    public void AddProgress()
    {
        currentAlpha += alphaStep;

        currentAlpha = Mathf.Clamp01(currentAlpha);

        SetAlpha(currentAlpha);
        AtualizarTexto();
    }

    public void ResetBackground()
    {
        currentAlpha = 0f;

        SetAlpha(currentAlpha);
        AtualizarTexto();
    }

    void SetAlpha(float a)
    {
        if (coloredBackground == null) return;

        Color c = coloredBackground.color;
        coloredBackground.color = new Color(c.r, c.g, c.b, a);
    }

    void AtualizarTexto()
    {
        if (porcentagemTexto == null)
            return;

        int porcentagem = Mathf.RoundToInt(currentAlpha * 100f);

        porcentagemTexto.text = "Mundo Restaurado: " + porcentagem + "%";
    }
}