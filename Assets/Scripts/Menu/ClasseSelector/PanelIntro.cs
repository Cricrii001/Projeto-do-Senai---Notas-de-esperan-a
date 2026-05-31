using UnityEngine;

public class PanelIntro : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    [SerializeField] private float moveDistance = 0.5f;
    [SerializeField] private float speed = 5f;

    private Vector3 startPos;
    private Vector3 targetPos;

    private Color startColor;
    private Color targetColor;

    private float t;

    private void OnEnable()
    {
        startPos = transform.position - Vector3.right * moveDistance;
        targetPos = transform.position;

        transform.position = startPos;

        startColor = sprite.color;
        startColor.a = 0f;

        targetColor = sprite.color;
        targetColor.a = 1f;

        sprite.color = startColor;

        t = 0f;
    }

    private void Update()
    {
        if (t < 1f)
        {
            t += Time.deltaTime * speed;

            transform.position =
                Vector3.Lerp(startPos, targetPos, t);

            sprite.color =
                Color.Lerp(startColor, targetColor, t);
        }
    }
}