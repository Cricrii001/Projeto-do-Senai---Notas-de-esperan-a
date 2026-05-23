using UnityEngine;

public class MissionPanel : MonoBehaviour
{
    public GameObject painelMissoes;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            painelMissoes.SetActive(
                !painelMissoes.activeSelf
            );
        }
    }
}