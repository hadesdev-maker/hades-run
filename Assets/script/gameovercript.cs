using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;

    void Start()
    {
        float currentScore = PlayerPrefs.GetFloat("CurrentScore", 0f);

        currentScoreText.text = "Current Score: " + Mathf.FloorToInt(currentScore).ToString();
    }
}
