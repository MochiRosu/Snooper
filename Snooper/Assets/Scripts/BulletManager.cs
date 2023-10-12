using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletManager : MonoBehaviour
{
    public int maxBullets = 5; // Maximum bullets you can have
    private int currentBullets; // Current bullets remaining
    public GameObject gameOverScreen;

    void Start()
    {
        currentBullets = maxBullets;
        // Hide the game over screen at the start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentBullets > 0)
        {
            // Reduce the bullet count and shoot
            currentBullets--;
            // Add your shooting logic here
        }
        else
        {
            // Show the "You Lose" screen or perform game over logic
            HandleGameOver();
        }
    }

    void HandleGameOver()
    {
        // Show the game over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
