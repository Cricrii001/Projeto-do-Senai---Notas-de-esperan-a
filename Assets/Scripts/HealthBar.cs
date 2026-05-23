using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public TextMeshProUGUI healthText;

    public PlayerHealth playerHealth;

    void Update()
    {
        fillBar.fillAmount =
            (float)playerHealth.currentHealth /
            playerHealth.maxHealth;

        healthText.text =
            playerHealth.currentHealth +
            " / " +
            playerHealth.maxHealth;
    }
}