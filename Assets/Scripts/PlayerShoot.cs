using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform firePoint;
    public float shootForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject note = Instantiate(
            notePrefab,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = note.GetComponent<Rigidbody2D>();

        float direction = transform.localScale.x;

        rb.velocity = new Vector2(direction * shootForce, 0f);
    }
}