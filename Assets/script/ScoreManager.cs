using UnityEngine;
using TMPro;
using System.Collections;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText; // New TextMeshProUGUI for displaying the "New High Score" text
    public float initialScoreIncreaseRate = 8f;
    public float scoreIncreaseRateIncrement = 0.2f;
    public float highScoreDisplayDuration = 1f; // Duration to display the "New High Score" text

    private float score;
    private float currentScoreIncreaseRate;
    private float elapsedTime;
    private bool newHighScoreDisplayed;

    void Start()
    {
        score = 0;
        currentScoreIncreaseRate = initialScoreIncreaseRate;
        elapsedTime = 0;
        newHighScoreDisplayed = false;
        highScoreText.gameObject.SetActive(false); // Hide the "New High Score" text initially
        UpdateScoreText();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // Increase the score based on the current score increase rate
        score += currentScoreIncreaseRate * Time.deltaTime;

        // Gradually increase the score increase rate over time
        currentScoreIncreaseRate += scoreIncreaseRateIncrement * Time.deltaTime;

        // Update the score text
        UpdateScoreText();

        // Check for a new high score
        CheckForNewHighScore();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    void CheckForNewHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);

        if (score > highScore && !newHighScoreDisplayed)
        {
            newHighScoreDisplayed = true;
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
            StartCoroutine(DisplayNewHighScoreText());
        }
    }

    IEnumerator DisplayNewHighScoreText()
    {
        highScoreText.gameObject.SetActive(true);
        yield return new WaitForSeconds(highScoreDisplayDuration);
        highScoreText.gameObject.SetActive(false);
    }

    public void SaveScores()
    {
        PlayerPrefs.SetFloat("CurrentScore", score);
        PlayerPrefs.Save();
    }

    void OnDestroy()
    {
        SaveScores();
    }
}
