using UnityEngine;

public class XPOrb : MonoBehaviour
{
    public int xpValue = 5;

    public float moveSpeed = 6f;
    public float detectRange = 3f;

    private Transform player;
    private PlayerXP playerXP;

    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("Player");

        if (obj != null)
        {
            player = obj.transform;
            playerXP = obj.GetComponent<PlayerXP>();
        }
    }

    void Update()
    {
        if (playerXP == null) return;

        // 🔴 SE CHEIO → ORB PARA TOTALMENTE
        if (playerXP.IsFull())
            return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerXP xp = collision.GetComponent<PlayerXP>();

        if (xp == null) return;

        // 🔴 DUPLA PROTEÇÃO
        if (xp.IsFull())
            return;

        xp.AddXP(xpValue);

        Destroy(gameObject);
    }
}