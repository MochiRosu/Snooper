using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int maxBullets = 5;
    private int currentBullets;
    public TMP_Text bulletsText;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;
    public GameObject enemyPrefab;

    private int totalEnemies;
    private int enemiesDefeated;
    private bool gameEnded = false; // Variable to track whether the game has ended

    void Start()
    {
        currentBullets = maxBullets;
        bulletsText.text = "Bullets: " + currentBullets + " / " + maxBullets;
        gameOverScreen.SetActive(false);
        youWinScreen.SetActive(false);

        totalEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemiesDefeated = 0;
    }

    void Update()
    {
        if (!gameEnded) // Only allow shooting when the game hasn't ended
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        CheckWinCondition(); // Check for the win condition continuously
    }

    void Shoot()
    {
        if (!gameEnded && currentBullets > 0)
        {
            currentBullets--;
            bulletsText.text = "Bullets: " + currentBullets + " / " + maxBullets;

            // Your shooting logic here
        }
        else if (!gameEnded)
        {
            HandleGameOver();
        }
    }

    void HandleGameOver()
    {
        gameEnded = true; // Mark the game as ended
        gameOverScreen.SetActive(true);
    }

    void HandleGameWin()
    {
        gameEnded = true; // Mark the game as ended
        youWinScreen.SetActive(true);
    }

    void CheckWinCondition()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            HandleGameWin();
        }
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
    }
}
