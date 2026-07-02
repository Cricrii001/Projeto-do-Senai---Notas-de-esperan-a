using UnityEngine;

public class FecharJogo : MonoBehaviour
{
    public void SairDoJogo()
    {
        Application.Quit();

        // Funciona apenas dentro da Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}