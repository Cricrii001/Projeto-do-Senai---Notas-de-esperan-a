using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        // Mantém este objeto entre cenas
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Garante que o jogo nunca comece pausado
        Time.timeScale = 1f;
    }

    // Carrega qualquer cena pelo nome
    public void CarregarCena(string nomeCena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeCena);
    }

    // Reinicia a cena atual
    public void ReiniciarCena()
    {
        Time.timeScale = 1f;

        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }

    // Pausa jogo
    public void PausarJogo()
    {
        Time.timeScale = 0f;
    }

    // Continua jogo
    public void ContinuarJogo()
    {
        Time.timeScale = 1f;
    }

    // Alterna pausa
    public void AlternarPausa()
    {
        Time.timeScale = (Time.timeScale == 0f) ? 1f : 0f;
    }

    // Fecha jogo
    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Jogo fechado");
    }
}