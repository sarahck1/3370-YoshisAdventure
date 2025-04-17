using UnityEngine;
using UnityEngine.SceneManagement;  // For scene management

public class GameManager : MonoBehaviour
{
    // Method to restart the game
    public void RestartGame()
    {
        Time.timeScale = 1;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
