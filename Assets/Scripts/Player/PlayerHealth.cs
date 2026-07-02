using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthFill;
    public GameObject gameOverPanel;

    private bool isDead = false;
    private SpriteRenderer sr;

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateBar();
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateBar();

        Debug.Log("Vida atual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateBar()
    {
        if (healthFill == null) return;

        float percent = (float)currentHealth / maxHealth;
        healthFill.fillAmount = percent;

        if (percent > 0.6f)
            healthFill.color = Color.green;
        else if (percent > 0.25f)
            healthFill.color = new Color(1f, 0.85f, 0f);
        else if (percent > 0.1f)
            healthFill.color = new Color(1f, 0.5f, 0f);
        else
            healthFill.color = Color.red;
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;

        Debug.Log("PLAYER MORREU");

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Debug.Log("GameOver ativado: " + gameOverPanel.activeSelf);
        }
        else
        {
            Debug.LogError("GameOverPanel não atribuído!");
        }

        if (sr != null)
            sr.enabled = false;

        Time.timeScale = 0f;
    }
}