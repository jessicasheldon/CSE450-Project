using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public List<int> topScores = new List<int>();

    void Start()
    {
        LoadScores();
    }

    public void UpdateScores(int newScore)
    {
        topScores.Add(newScore);
        topScores.Sort((a, b) => b.CompareTo(a)); // Sort in descending order

        if (topScores.Count > 3)
        {
            topScores.RemoveAt(3); // Keep only top 3 scores
        }

        SaveScores();
    }

    void SaveScores()
    {
        for (int i = 0; i < topScores.Count; i++)
        {
            PlayerPrefs.SetInt("Score" + i, topScores[i]);
        }
    }

    void LoadScores()
    {
        topScores.Clear();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey("Score" + i))
            {
                topScores.Add(PlayerPrefs.GetInt("Score" + i));
            }
        }
    }
}
