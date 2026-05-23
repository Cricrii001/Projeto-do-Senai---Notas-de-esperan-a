using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private float movement;

    public bool isGrounded;

    private Vector3 originalScale;

    // Painel de missões
    public GameObject painelMissoes;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // salva a escala inicial do personagem
        originalScale = transform.localScale;
    }

    void Update()
    {
    // Abrir/fechar missões com M
    if (Input.GetKeyDown(KeyCode.M))
    {
        painelMissoes.SetActive(
            !painelMissoes.activeSelf
        );

        Time.timeScale = painelMissoes.activeSelf ? 0 : 1;
    }

    // Se o jogo estiver pausado, para aqui
    if (Time.timeScale == 0)
        return;

    movement = Input.GetAxisRaw("Horizontal");

    // virar player sem alterar tamanho
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

    // pulo
    if ((Input.GetKeyDown(KeyCode.UpArrow) ||
         Input.GetKeyDown(KeyCode.W))
         && isGrounded)
        {
        rb.velocity = new Vector2(
            rb.velocity.x,
            jumpForce
        );
        }
    }

    void FixedUpdate()
    {
        // impede movimento quando o painel estiver aberto
        if (Time.timeScale == 0)
            return;

        rb.velocity = new Vector2(
            movement * speed,
            rb.velocity.y
        );
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