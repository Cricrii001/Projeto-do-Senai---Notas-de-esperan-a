using UnityEngine;

public class BotaoSprite : MonoBehaviour
{
    public string classe;

    private void OnMouseDown()
    {
        GameManager.Instance.SelecionarClasse(classe);
        GameManager.Instance.CarregarCena("Tutorial");
    }
}