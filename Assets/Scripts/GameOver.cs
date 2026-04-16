using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;          
    public GameObject gameOverPanel; 
    public Text finalScoreText;     

    private float maxHeight;
    private int score;
    private bool isDead = false;

    void Start()
    {
        maxHeight = transform.position.y;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isDead) return;

        if (transform.position.y > maxHeight)
        {
            maxHeight = transform.position.y;
            score = (int)(maxHeight * 10);
        }

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        float cameraBottom = Camera.main.transform.position.y -
                             Camera.main.orthographicSize - 1f;

        if (transform.position.y < cameraBottom)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);

            if (finalScoreText != null)
                finalScoreText.text = "Score: " + score;
        }

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
