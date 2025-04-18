using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Yoshi_Health : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public int maxLives = 3;
    public int currentLives;

    public Image[] flowerIcons; 
    public Sprite fullFlower;
    public Sprite emptyFlower;

    private void Start()
    {
        currentLives = maxLives;

        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }

        UpdateFlowersUI();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("shyguy_enemy"))
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        currentLives--;

        UpdateFlowersUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }

        Time.timeScale = 0;
        this.gameObject.SetActive(false);
        ShowGameOver();
    }

    void ShowGameOver()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateFlowersUI()
    {
        if (flowerIcons != null && flowerIcons.Length > 0)
        {
            for (int i = 0; i < flowerIcons.Length; i++)
            {
                if (i < currentLives)
                {
                    flowerIcons[i].sprite = fullFlower;
                }
                else
                {
                    flowerIcons[i].sprite = emptyFlower;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D fruitCollider)
{
    if (fruitCollider.CompareTag("Fruit"))
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateFlowersUI();
        }

        Destroy(fruitCollider.gameObject); // remove the fruit after picking it up
    }
}
void Update()
{
    if (transform.position.y < -6f) // Adjust value depending on your level
    {
        currentLives = 0;
        GameOver();
    }
}

}
