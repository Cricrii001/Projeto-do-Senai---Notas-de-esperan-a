using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    public EnemyHealth health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

            if (rb.velocity.y < 0)
            {
                health.TakeDamage(1);
                rb.velocity = new Vector2(rb.velocity.x, player.jumpForce * 0.6f);
            }
        }
    }
}