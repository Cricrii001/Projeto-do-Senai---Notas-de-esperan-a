using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player;

    public float smooth = 5f;

    // limites do mapa
    public float minX;
    public float maxX;

    void LateUpdate()
    {
        if (player == null) return;

        float targetX = player.position.x;

        // 🔥 trava nos limites do cenário
        targetX = Mathf.Clamp(targetX, minX, maxX);

        Vector3 targetPos = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
    }
}