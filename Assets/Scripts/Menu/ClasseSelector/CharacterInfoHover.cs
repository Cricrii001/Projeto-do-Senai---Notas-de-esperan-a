using UnityEngine;

public class CharacterInfoHover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer painel;
    [SerializeField] private float velocidadeFade = 8f;

    private float alphaAlvo;

    private void Start()
    {
        Color cor = painel.color;
        cor.a = 0f;
        painel.color = cor;

        alphaAlvo = 0f;
    }

    private void Update()
    {
        Color cor = painel.color;

        cor.a = Mathf.MoveTowards(
            cor.a,
            alphaAlvo,
            velocidadeFade * Time.deltaTime
        );

        painel.color = cor;
    }

    private void OnMouseEnter()
    {
        alphaAlvo = 1f;
    }

    private void OnMouseExit()
    {
        alphaAlvo = 0f;
    }
}