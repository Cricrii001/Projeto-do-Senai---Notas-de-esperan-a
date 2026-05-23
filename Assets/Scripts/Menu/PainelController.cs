using UnityEngine;

public class PainelController : MonoBehaviour
{
    public GameObject painel;

    public void AbrirPainel()
    {
        painel.SetActive(true);
    }

    public void FecharPainel()
    {
        painel.SetActive(false);
    }
}