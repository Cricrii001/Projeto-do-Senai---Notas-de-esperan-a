using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image healthFill;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateBar();
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateBar()
    {
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
        Debug.Log("MORREU");
        SceneManager.LoadScene("Menu");
    }
}