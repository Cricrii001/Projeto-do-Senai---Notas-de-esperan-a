using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    private EnemySimple enemy;

    void Start()
    {
        enemy = GetComponentInParent<EnemySimple>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.TakeDamage();
        }
    }
}