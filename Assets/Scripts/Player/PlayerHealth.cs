using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 450;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
            currentHealth = 0;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}