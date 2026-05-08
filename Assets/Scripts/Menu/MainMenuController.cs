using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [Header("Referências")]
    public RectTransform logo;

    public GameObject pressText;
    public GameObject mainMenu;

    [Header("Movimento da Logo")]
    public Vector2 targetPosition = new Vector2(-500, 100);

    public float moveDuration = 1f;

    [Header("Animação")]
    public bool useSmoothStep = true;

    bool started = false;

    Vector2 startPos;

    float timer = 0f;

    void Start()
    {
        // salva posição inicial
        startPos = logo.anchoredPosition;

        // esconde menu
        mainMenu.SetActive(false);
    }

    void Update()
    {
        // detecta qualquer tecla
        if (!started && Input.anyKeyDown)
        {
            started = true;

            // esconde texto
            pressText.SetActive(false);

            // mostra menu
            mainMenu.SetActive(true);
        }

        // animação da logo
        if (started)
        {
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(timer / moveDuration);

            // easing opcional
            if (useSmoothStep)
            {
                t = Mathf.SmoothStep(0, 1, t);
            }

            // move a logo
            logo.anchoredPosition =
                Vector2.Lerp(startPos, targetPosition, t);
        }
    }
}