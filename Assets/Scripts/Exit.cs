using UnityEngine;

public class QuitManager : MonoBehaviour
{
    public void QuitGame()
    {
        // Quits the application when running as a standalone build
        Application.Quit();

        // Stops Play Mode when running inside the Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

