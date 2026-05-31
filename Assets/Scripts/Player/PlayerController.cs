using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private float movement;

    public bool isGrounded;

    private Vector3 originalScale;

    public GameObject painelMissoes;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;

        AplicarClasse(); // 🔥 AQUI
    }

    void AplicarClasse()
    {
        if (GameManager.Instance == null) return;

        string classe = GameManager.Instance.classeSelecionada;

        Debug.Log("Classe recebida: " + classe);

        if (classe == "Artista")
        {
            speed = 4f;
            jumpForce = 9f;
        }
        else if (classe == "Rapper")
        {
            speed = 6f;
            jumpForce = 8f;
        }
        else
        {
            speed = 5f;
            jumpForce = 8f;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            painelMissoes.SetActive(!painelMissoes.activeSelf);
            Time.timeScale = painelMissoes.activeSelf ? 0 : 1;
        }

        if (Time.timeScale == 0)
            return;

        movement = Input.GetAxisRaw("Horizontal");

        Vector3 scale = originalScale;

        if (movement > 0)
        {
            scale.x = Mathf.Abs(originalScale.x);
        }
        else if (movement < 0)
        {
            scale.x = -Mathf.Abs(originalScale.x);
        }

        transform.localScale = scale;

        if ((Input.GetKeyDown(KeyCode.UpArrow) ||
             Input.GetKeyDown(KeyCode.W))
             && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}