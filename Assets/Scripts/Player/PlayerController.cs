using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject hudRoqueiro;
    public GameObject hudRapper;
    public GameObject hudPoeta;
    public GameObject hudArtista;

    private Animator anim;
    private SpriteRenderer sr;

    public float speed = 5f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private float movement;

    private bool isJumping;

    public bool isGrounded;

    public GameObject painelMissoes;

    private bool isAttacking = false;
    private bool isShooting = false; // 👈 NOVO

    public int health = 3;
    private bool canTakeDamage = true;

    // 👊 HITBOX
    public GameObject attackHitbox;
    private Vector3 hitboxStartPos;

    // 🎵 PROJÉTIL
    public GameObject projectilePrefab1;
    public GameObject projectilePrefab2;

    private bool usarPrimeiroProjetil = true;



    public Transform firePoint;
    public float projectileSpeed = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        if (attackHitbox != null)
        {
            hitboxStartPos = attackHitbox.transform.localPosition;
            attackHitbox.SetActive(false);
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

        // Só trava movimento durante o ataque corpo a corpo
        if (isAttacking)
        {
            movement = 0;
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetFloat("Speed", 0);
            return;
        }

        movement = Input.GetAxisRaw("Horizontal");

        // Flip do personagem
        if (movement != 0)
            sr.flipX = movement < 0;

        // 👊 Ataque corpo a corpo
        if (Input.GetKeyDown(KeyCode.J) && isGrounded)
        {
            Atacar();
        }

        // 👉 Tiro
        if (Input.GetKeyDown(KeyCode.F) && isGrounded && !isShooting)
        {
            Atirar();
        }

        // Pulo
        if ((Input.GetKeyDown(KeyCode.UpArrow) ||
             Input.GetKeyDown(KeyCode.W) ||
             Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        anim.SetFloat("Speed", Mathf.Abs(movement));
        HandleJumpAnimation();
        UpdateHitboxDirection();
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 0 || isAttacking)
            return;

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    // ==========================
    // ATAQUE CORPO A CORPO
    // ==========================

    void Atacar()
    {
        if (isAttacking || !isGrounded)
            return;

        isAttacking = true;

        movement = 0;
        rb.velocity = Vector2.zero;

        anim.SetFloat("Speed", 0);
        anim.SetTrigger("Attack");

        if (attackHitbox != null)
            attackHitbox.SetActive(true);
    }

    public void FimAtaque()
    {
        isAttacking = false;

        if (attackHitbox != null)
            attackHitbox.SetActive(false);
    }

    // ==========================
    // TIRO
    // ==========================

    void Atirar()
    {
        if (isShooting)
            return;

        isShooting = true;

        anim.SetTrigger("Shoot");
    }

    public void FimTiro()
    {
        isShooting = false;
    }

    // ==========================
    // HITBOX
    // ==========================

    void UpdateHitboxDirection()
    {
        if (attackHitbox == null) return;

        Vector3 pos = hitboxStartPos;

        pos.x = Mathf.Abs(hitboxStartPos.x) * (sr.flipX ? -1 : 1);

        attackHitbox.transform.localPosition = pos;
    }

    // Chamado por um Animation Event
    public void ShootProjectile()
    {
        if (firePoint == null)
            return;

        GameObject prefabEscolhido = usarPrimeiroProjetil
            ? projectilePrefab1
            : projectilePrefab2;

        usarPrimeiroProjetil = !usarPrimeiroProjetil;

        if (prefabEscolhido == null)
            return;

        GameObject projectile = Instantiate(
            prefabEscolhido,
            firePoint.position,
            Quaternion.identity
        );

        // Ignora colisão com o próprio player
        Collider2D playerCol = GetComponent<Collider2D>();
        Collider2D projectileCol = projectile.GetComponent<Collider2D>();

        if (playerCol != null && projectileCol != null)
        {
            Physics2D.IgnoreCollision(playerCol, projectileCol);
        }

        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

        if (projectileRb != null)
        {
            float direction = sr.flipX ? -1f : 1f;
            projectileRb.velocity = new Vector2(direction * projectileSpeed, 0);
        }

        SpriteRenderer projectileSR = projectile.GetComponent<SpriteRenderer>();

        if (projectileSR != null)
        {
            projectileSR.flipX = sr.flipX;
            projectileSR.flipY = false;
        }
    }

    // ==========================
    // VIDA
    // ==========================

    public void TakeDamage()
    {
        PlayerHealth health = GetComponent<PlayerHealth>();

        if (health.currentHealth <= 0)
            return;

        if (!canTakeDamage)
            return;

        health.TakeDamage(10);

        if (health.currentHealth > 0)
            StartCoroutine(BlinkPlayer());
    }

    System.Collections.IEnumerator BlinkPlayer()
    {
        canTakeDamage = false;

        for (int i = 0; i < 3; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        canTakeDamage = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void HandleJumpAnimation()
    {
        if (!isGrounded)
        {
            isJumping = true;
            anim.SetBool("isJumping", true);
        }
        else
        {
            if (isJumping)
            {
                isJumping = false;
                anim.SetBool("isJumping", false);
            }
        }
    }



}