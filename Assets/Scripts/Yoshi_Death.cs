using UnityEngine;
using UnityEngine.SceneManagement;  // For loading the scene
using UnityEngine.UI;  // For UI elements like Text

public class Yoshi_Death : MonoBehaviour
{
    public GameObject gameOverCanvas;
 

    private void Start()
    {
        // hide game over text at start
        if (gameOverCanvas != null)
        {
            //gameOverText.SetActive(false);
            gameOverCanvas.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shyguy_enemy"))
        {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }   
            // show the Game Over message
            Time.timeScale = 0;
            this.gameObject.SetActive(false);
            ShowGameOver();
        }

       // if (collision.gameObject.CompareTag("power_up"))
       // {
       //     Destroy(collision.gameObject); 
       //     score_manager.instance.addPoints();  
       // }
    }

    void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            // Show the Game Over message
            gameOverCanvas.SetActive(true);
        }

        // Pause the game (optional, to stop movement, etc.)
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Unpause the game and reload the current scene to restart
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
