using UnityEngine;

public class PressStartAnimation : MonoBehaviour
{
    [Header("Piscar")]
    public float blinkSpeed = 3f;
    public float minAlpha = 0.3f;

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
        float alpha = Mathf.Lerp(
            minAlpha,
            1f,
            (Mathf.Sin(Time.time * blinkSpeed) + 1f) / 2f
        );

        canvasGroup.alpha = alpha;
    }
}