using TMPro;
using UnityEngine;

public class ScoreboardUI : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Assign these in the inspector
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene
        gameObject.SetActive(false); // Hide the scoreboard initially
    }

    public void UpdateScoreboard()
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < scoreManager.topScores.Count)
            {
                scoreTexts[i].text = scoreManager.topScores[i].ToString();
            }
            else
            {
                scoreTexts[i].text = "0000";
            }
        }
    }

    public void Show()
    {
        UpdateScoreboard();
        gameObject.SetActive(true); // Show the scoreboard
    }

    public void Hide()
    {
        gameObject.SetActive(false); // Hide the scoreboard
    }
}
