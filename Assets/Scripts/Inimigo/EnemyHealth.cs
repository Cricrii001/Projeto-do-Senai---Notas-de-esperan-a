using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    [Header("XP Drop")]
    public GameObject xpOrbPrefab;
    public int minXPDrop = 2;
    public int maxXPDrop = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Quantidade aleatória de orbs
            int quantidade = Random.Range(minXPDrop, maxXPDrop + 1);

            for (int i = 0; i < quantidade; i++)
            {
                Vector2 offset = Random.insideUnitCircle * 0.3f;

                Instantiate(
                    xpOrbPrefab,
                    (Vector2)transform.position + offset,
                    Quaternion.identity
                );
            }

            EnemySpawner.enemiesAlive--;

            Destroy(gameObject);
        }
    }
}