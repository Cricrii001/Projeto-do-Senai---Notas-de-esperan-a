using UnityEngine;

public class PressStartAnimation : MonoBehaviour
{
    [Header("Piscar")]
    public float blinkSpeed = 3f;
    public float minAlpha = 0.3f;

    [Header("Rotação")]
    public float rotationAmount = 5f;
    public float rotationSpeed = 2f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    void Update()
    {
        // pisca
        float alpha = Mathf.Lerp(
            minAlpha,
            1f,
            (Mathf.Sin(Time.time * blinkSpeed) + 1) / 2
        );

        canvasGroup.alpha = alpha;

        // gira para os lados
        float rotation =
            Mathf.Sin(Time.time * rotationSpeed)
            * rotationAmount;

        transform.rotation =
            Quaternion.Euler(0, 0, rotation);
    }
}