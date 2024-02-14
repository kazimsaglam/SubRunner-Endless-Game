using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Character characterScript;
    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    private float score = 0;
    private float highestScore = 999;
    private int health = 3;
    [HideInInspector]public bool isDead = false;

    private void Start()
    {
        UpdateHealthUI();
        gameOverPanel.SetActive(false);

        highestScore = Mathf.RoundToInt(PlayerPrefs.GetFloat("HighestScore", 0f));
    }

    private void Update()
    {
        UpdateScore();
        CheckHighestScore();

        if (Input.GetKeyDown(KeyCode.R))
            Die();


        if (health <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Scenes/InGame");
        }
    }

    private void UpdateScore()
    {
        score += Time.deltaTime * 50;
        scoreText.text = $"SKOR: {Mathf.RoundToInt(score)}";
    }

    private void CheckHighestScore()
    {
        if (score > Mathf.RoundToInt(PlayerPrefs.GetFloat("HighestScore", 0f)))
        {
            scoreText.color = Color.green;
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
    }

    public void SaveScore()
    {
        if(score > highestScore)
        {
            highestScore = score;
            PlayerPrefs.SetFloat("HighestScore", highestScore);
            PlayerPrefs.Save();
        }

        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.Save();
    }

    void UpdateHealthUI()
    {
        healthText.text = "CAN: " + health.ToString();
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Die();
        }

        UpdateHealthUI();
    }

    void Die()
    {
        characterScript.gameObject.SetActive(false);
        SaveScore();

        scoreText.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);

        gameOverPanel.SetActive(true);
    }
}
