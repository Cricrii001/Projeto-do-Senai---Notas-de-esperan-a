using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string classeSelecionada;

    private void Awake()
    {
        // Singleton simples (evita duplicar entre cenas)
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // 🔥 CHAMADA PRINCIPAL (usada pelo botão sprite)
    public void CarregarCena(string nomeCena)
    {
        Debug.Log("CHAMOU: " + nomeCena);

        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeCena);
    }

    public void ReiniciarCena()
    {
        Time.timeScale = 1f;
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }

    public void PausarJogo()
    {
        Time.timeScale = 0f;
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1f;
    }

    public void AlternarPausa()
    {
        Time.timeScale = (Time.timeScale == 0f) ? 1f : 0f;
    }

    public void SairJogo()
    {
        Debug.Log("Jogo fechado");
        Application.Quit();
    }

    public void SelecionarClasse(string classe)
    {
        classeSelecionada = classe;
    }
}