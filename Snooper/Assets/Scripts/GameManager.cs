using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int maxBullets = 5;
    private int currentBullets;
    public TextMeshProUGUI bulletsText;
    public GameObject gameOverScreen;
    public GameObject youWinScreen;

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

        if (enemiesDefeated >= totalEnemies)
        {
            HandleGameWin();
        }
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

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
    }
}
