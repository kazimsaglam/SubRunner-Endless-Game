using UnityEngine;
using TMPro;
using System.Collections;

public class GameOverScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highestScoreText;
    public TextMeshProUGUI scoreText;
    public GameObject pressText;

    private void Start()
    {
        DisplayScore();
        StartCoroutine(GameOverBlink());
    }

    void DisplayScore()
    {
        int savedScore = Mathf.RoundToInt(PlayerPrefs.GetFloat("Score", 0f));

        scoreText.text = "SKOR: " + savedScore.ToString();

        highestScoreText.text = "EN YUKSEK SKOR: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighestScore", 0f)).ToString();
    }

    private IEnumerator GameOverBlink()
    {
        while (true)
        {
            pressText.SetActive(!pressText.activeSelf);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
