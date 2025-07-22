using UnityEngine;
using UnityEngine.SceneManagement;

public class RESET : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public void Retry()
    {
        scoreManager.SaveScores(); if (scoreManager != null)
        {
            scoreManager.SaveScores();
        }
        roadmovement.ResetSpeed(); // Reset the speed
        SceneManager.LoadScene(1);// Reload the current scene
    }

    public void LoadHomeScreen()
    {
        if (scoreManager != null)
        {
            scoreManager.SaveScores();
        }
        roadmovement.ResetSpeed(); // Reset the speed
        SceneManager.LoadScene(0); // Load the home screen scene by name
    }

    public void LoadGameScene()
    {
        if (scoreManager != null)
        {
            scoreManager.SaveScores();
        }
        roadmovement.ResetSpeed(); // Reset the speed
        SceneManager.LoadScene(1); // Load the game scene by name
    }
}
