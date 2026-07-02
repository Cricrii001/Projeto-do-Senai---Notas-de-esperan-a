using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;

    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemy = collision.GetComponent<EnemyHealth>();

        if (collision.CompareTag("Player"))
            return;

        if (enemy != null)
        {
            enemy.TakeDamage(damage);

            Destroy(gameObject);
        }

        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}