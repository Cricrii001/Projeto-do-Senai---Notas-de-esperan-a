using UnityEngine;
using TMPro;

public class BackgroundProgress : MonoBehaviour
{
    public SpriteRenderer coloredBackground;
    public TMP_Text porcentagemTexto;

    public GameObject vitoriaPanel;
    public GameObject player; // 👈 ADICIONADO

    [Range(0f, 1f)]
    public float alphaStep = 0.03f;

    private float currentAlpha = 0f;
    private bool hasWon = false;

    void Start()
    {
        currentAlpha = 0f;

        SetAlpha(currentAlpha);
        AtualizarTexto();

        if (vitoriaPanel != null)
            vitoriaPanel.SetActive(false);
    }

    public void AddProgress()
    {
        if (hasWon) return;

        currentAlpha += alphaStep;
        currentAlpha = Mathf.Clamp01(currentAlpha);

        SetAlpha(currentAlpha);
        AtualizarTexto();

        if (currentAlpha >= 1f)
        {
            Win();
        }
    }

    public void ResetBackground()
    {
        currentAlpha = 0f;
        hasWon = false;

        SetAlpha(currentAlpha);
        AtualizarTexto();

        if (vitoriaPanel != null)
            vitoriaPanel.SetActive(false);
    }

    void Win()
    {
        if (hasWon) return;

        hasWon = true;

        Debug.Log("VITÓRIA!");

        if (vitoriaPanel != null)
            vitoriaPanel.SetActive(true);

        // 🧨 DESTROI O PLAYER
        if (player != null)
            Destroy(player);

        Time.timeScale = 0f;
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