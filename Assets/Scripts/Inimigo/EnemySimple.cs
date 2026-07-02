using UnityEngine;

public class EnemySimple : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float speed = 2f;

    // direção inicial (1 = direita, -1 = esquerda)
    private int direction = -1;

    private EnemyHealth health;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();

        // 🔥 FLIP INICIAL
        Flip();
    }

    void Update()
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        if (anim != null)
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 🧱 PAREDE → vira direção + flip
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
            return;
        }

        // 👤 PLAYER → dano
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player == null) return;

            Rigidbody2D playerRb = player.GetComponent<Rigidbody2D>();

            float playerBottom = player.transform.position.y;
            float enemyTop = transform.position.y + 0.5f;

            bool isFalling = playerRb.velocity.y <= 0.1f;
            bool isStomping = isFalling && playerBottom > enemyTop;

            if (isStomping)
            {
                if (health != null)
                    health.TakeDamage(1);

                playerRb.velocity = new Vector2(playerRb.velocity.x, player.jumpForce * 0.6f);
            }
            else
            {
                player.TakeDamage();
            }
        }
    }

    // 🔁 troca direção + flip
    void ChangeDirection()
    {
        direction *= -1;
        Flip();
    }

    // 👀 vira sprite corretamente
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
    }
}