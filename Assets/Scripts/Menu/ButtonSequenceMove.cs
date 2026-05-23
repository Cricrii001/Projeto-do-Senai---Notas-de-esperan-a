using System.Collections;
using UnityEngine;

public class ButtonSequenceMove : MonoBehaviour
{
    [Header("Botões na ordem")]
    public RectTransform[] buttons;

    [Header("Posições finais")]
    public RectTransform[] targetPositions;

    [Header("Configurações")]
    public float moveSpeed = 700f;
    public float delayBetween = 0.15f;

    private bool started = false;

    void Update()
    {
        if (!started && Input.anyKeyDown)
        {
            started = true;
            StartCoroutine(MoveButtonsCascade());
        }
    }

    IEnumerator MoveButtonsCascade()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            // Verifica se o botão e a posição alvo foram arrastados no Inspector para evitar erros
            if (buttons[i] != null && targetPositions[i] != null)
            {
                // Torna o botão visível/ativo no momento em que ele deve começar a se mover
                buttons[i].gameObject.SetActive(true);

                // Começa o movimento do botão atual
                StartCoroutine(MoveButton(buttons[i], targetPositions[i]));
            }

            // Espera um pouco antes do próximo
            yield return new WaitForSeconds(delayBetween);
        }
    }

    IEnumerator MoveButton(RectTransform button, RectTransform target)
    {
        while (Vector2.Distance(button.anchoredPosition, target.anchoredPosition) > 1f)
        {
            button.anchoredPosition = Vector2.MoveTowards(
                button.anchoredPosition,
                target.anchoredPosition,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        button.anchoredPosition = target.anchoredPosition;
    }
}