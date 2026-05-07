using UnityEngine;

public class MusicalNote : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cenário"))
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();

            if (sr != null)
            {
                sr.color = Random.ColorHSV();
            }
        }

        Destroy(gameObject);
    }
}