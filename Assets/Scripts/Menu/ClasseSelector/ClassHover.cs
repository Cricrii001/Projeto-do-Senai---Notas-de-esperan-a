using UnityEngine;

public class ClassHover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    private Vector3 posInicial;
    private Vector3 posHover;

    private Color corInicial;
    private Color corHover;

    private bool mouseEmCima;

    private void Start()
    {
        posInicial = transform.position;
        posHover = posInicial + Vector3.right * 0.5f;

        corInicial = sprite.color;

        corHover = corInicial;
        corHover.a = 1f; // 100% visível
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            mouseEmCima ? posHover : posInicial,
            Time.deltaTime * 10f
        );

        sprite.color = Color.Lerp(
            sprite.color,
            mouseEmCima ? corHover : corInicial,
            Time.deltaTime * 10f
        );
    }

    private void OnMouseEnter()
    {
        mouseEmCima = true;
    }

    private void OnMouseExit()
    {
        mouseEmCima = false;
    }
}