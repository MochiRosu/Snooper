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
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        CheckWinCondition();
    }

    void Shoot()
    {
        if (currentBullets > 0)
        {
            currentBullets--;
            bulletsText.text = "Bullets: " + currentBullets + " / " + maxBullets;

            // Your shooting logic here
        }
        else
        {
            HandleGameOver();
        }
    }

    void HandleGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    void HandleGameWin()
    {
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
