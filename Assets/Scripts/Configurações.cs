using UnityEngine;

public class Configuracoes : MonoBehaviour
{
    public GameObject painelConfiguracoes;

    private bool menuAberto = false;

    void Start()
    {
        painelConfiguracoes.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuAberto)
            {
                FecharMenu();
            }
            else
            {
                AbrirMenu();
            }
        }
    }

    public void AbrirMenu()
    {
        painelConfiguracoes.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
        menuAberto = true;
    }

    public void FecharMenu()
    {
        painelConfiguracoes.SetActive(false);
        Time.timeScale = 1f; // Volta ao normal
        menuAberto = false;
    }
}