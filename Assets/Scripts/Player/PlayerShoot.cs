using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform firePoint;

    public float shootForce = 10f;
    public float upwardForce = 2f; // força pra cima

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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

        // velocidade horizontal + impulso vertical
        rb.velocity = new Vector2(
            direction * shootForce,
            upwardForce
        );
    }
}