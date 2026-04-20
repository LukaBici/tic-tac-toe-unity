using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class SceneChanger : MonoBehaviour
{
    // Function to load a scene by its name
    public void LoadByName()
    {
        SceneManager.LoadScene("Game");
    }

  
}

