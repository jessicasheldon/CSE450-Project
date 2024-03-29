using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Code;

public class FallingColorHandling : MonoBehaviour
{
    public ScoreManager scoreManager;
    public ScoreboardUI scoreboardUI;

    public SpriteRenderer targetColorRenderer; 
    public SpriteRenderer resultRenderer;

    public GameObject congratulationsMessage; 
    public GameObject playAgainButton;

    private Sprite targetColorSprite; 
    private Sprite resultSprite;

    public GameObject tutorialScreen;
    public GameObject xButton;

    private int[] lastColor = new int[4];
    private int lastIndex = 0;

    private bool objectsSpawning = false;
    private Code.ObstaclePlacement obstaclePlacement;

    private int score = 0;
    public Text scoreText;
    private int stage = 1;
    public Text stageText;

    private int lives = 3;
    public Text livesText;

    public bool shouldObjectsSpawn()
    {
        return objectsSpawning;
    }

    private void Start()
    {
        obstaclePlacement = FindObjectOfType<Code.ObstaclePlacement>();
        congratulationsMessage.SetActive(false);
        playAgainButton.SetActive(false);
        UpdateLivesText();
        ShowTutorialScreen();
    }
    

    private void ShowTutorialScreen()
    {
        objectsSpawning = false;
        tutorialScreen.SetActive(true);
        xButton.SetActive(true);
    }

    public void HideTutorialScreen()
    {
        objectsSpawning = true;
        scoreText.text = "Score: 0";
        stageText.text = "Stage 1";
        StartCoroutine(ShowStageNumber(2.0f));
        tutorialScreen.SetActive(false);
        xButton.SetActive(false);
        targetColorRenderer.gameObject.SetActive(true);
        resultRenderer.gameObject.SetActive(true);
        targetColorSprite = GetRandomTargetColorSprite();
        targetColorRenderer.sprite = targetColorSprite;
        resultSprite = Resources.Load<Sprite>("W");
        resultRenderer.sprite = resultSprite;
    }
    private void OnEnable()
    {
        ObstacleCollision.OnPlayerCollision += ShowPlayAgainMenu;
    }

    private void OnDisable()
    {
        ObstacleCollision.OnPlayerCollision -= ShowPlayAgainMenu;
    }

    // Method to show the Play Again menu
    public void ShowPlayAgainMenu()
    {
        // Update the score in ScoreManager
        scoreManager.UpdateScores(score);
        // Show the scoreboard
        scoreboardUI.Show();

        //congratulationsMessage.SetActive(false); 
        playAgainButton.SetActive(true);
        objectsSpawning = false;

        lives = 3; 
        UpdateLivesText();
        Time.timeScale = 0;
    }

    public void IncrementRedCount()
    {
        UpdateScore(10);
        UpdateLastColor(1);
        UpdateResultColor();
        CheckWinCondition();
    }

    public void IncrementYellowCount()
    {
        UpdateScore(10);
        UpdateLastColor(2);
        UpdateResultColor();
        CheckWinCondition();
    }

    public void IncrementBlueCount()
    {
        UpdateScore(10);
        UpdateLastColor(3);
        UpdateResultColor();
        CheckWinCondition();
    }

    private void UpdateLastColor(int color)
    {
        if (lastColor[0] == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                lastColor[i] = color;
            }
            return;
        }

        lastColor[lastIndex] = color;
        lastIndex = (lastIndex + 1) % 4;
    }

    private void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }

    private void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    private void UpdateStage()
    {
        stage += 1;
        stageText.text = "Stage " + stage;
    }

    private void ResetStage()
    {
        stage = 0;
        stageText.text = "Stage " + stage;
    }

    public void ResetColorMixing()
    {
    resultSprite = Resources.Load<Sprite>("W");
    resultRenderer.sprite = resultSprite;

    for (int i = 0; i < 4; i++)
    {
        lastColor[i] = 0;
    }
}

    private void UpdateResultColor()
    {
        resultSprite = GetResultColor();
        resultRenderer.sprite = resultSprite;
    }

    private void CheckWinCondition()
    {
        if (resultSprite == targetColorSprite)
        {
            UpdateScore(100);
            UpdateStage();
            obstaclePlacement.UpdateSpawnRate(stage);
            // Set a new target color
            targetColorSprite = GetRandomTargetColorSprite();
            targetColorRenderer.sprite = targetColorSprite;
            // Reset the result color to white
            resultSprite = Resources.Load<Sprite>("W");
            resultRenderer.sprite = resultSprite;
            // Reset the lastColor array
            for (int i = 0; i < 4; i++)
            {
                lastColor[i] = 0;
            }
            StartCoroutine(ShowStageNumber(2.0f));
            Debug.Log("Congratulations! You've matched the target color.");
        }
    }

    IEnumerator ShowStageNumber(float duration)
    {
        stageText.gameObject.SetActive(true); // Show the stage number
        yield return new WaitForSeconds(duration); // Wait for the specified duration
        stageText.gameObject.SetActive(false); // Hide the stage number
    }

    public void ClearObstacles()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void PlayAgain()
    {
        FindObjectOfType<ColorPlacement>().ClearObjects();
        FindObjectOfType<ObstaclePlacement>().ClearObstacles();
        scoreboardUI.Hide();
        score = 0;
        stage = 1;
        ResetScore();
        ResetStage();
        Time.timeScale = 1; 
        targetColorSprite = GetRandomTargetColorSprite();
        targetColorRenderer.sprite = targetColorSprite;
        resultSprite = Resources.Load<Sprite>("W");
        resultRenderer.sprite = resultSprite;
        congratulationsMessage.SetActive(false);
        playAgainButton.SetActive(false);
        objectsSpawning = true;
        obstaclePlacement.UpdateSpawnRate(stage);

        for (int i = 0; i < 4; i++)
        {
            lastColor[i] = 0;
        }

        lives = 3; 
        UpdateLivesText();
    }


private Sprite GetResultColor()
{
    int[] colorCounts = new int[4];
    int colorCount = 0;

    // Calculate the count of each color in the lastColor array
    for (int i = 0; i < 4; i++)
    {
        if (lastColor[i] != 0)
        {
            colorCounts[lastColor[i] - 1]++;
            colorCount++;
        }
    }

    bool hasRed = colorCounts[0] > 0;
    bool hasYellow = colorCounts[1] > 0;
    bool hasBlue = colorCounts[2] > 0;

    // Check if at least two colors are present to determine the resulting color
        if (hasRed && hasYellow && hasBlue)
        {
            return Resources.Load<Sprite>("B");
        }
        else if (hasRed && colorCounts[0] == 4)
        {
            return Resources.Load<Sprite>("R");
        }
        else if (hasYellow && colorCounts[1] == 4)
        {
            return Resources.Load<Sprite>("Y");
        }
        else if (hasBlue && colorCounts[2] == 4)
        {
            return Resources.Load<Sprite>("BB");
        }
        else if (hasRed && colorCounts[0] == 3 && colorCounts[1] == 1)
        {
            return Resources.Load<Sprite>("BO");
        }
        else if (hasRed && colorCounts[0] == 2 && colorCounts[1] == 2)
        {
            return Resources.Load<Sprite>("O");
        }
        else if (hasRed && colorCounts[0] == 1 && colorCounts[1] == 3)
        {
            return Resources.Load<Sprite>("SY");
        }
        else if (hasYellow && colorCounts[1] == 3 && colorCounts[2] == 1)
        {
            return Resources.Load<Sprite>("SG");
        }
        else if (hasYellow && colorCounts[1] == 2 && colorCounts[2] == 2)
        {
            return Resources.Load<Sprite>("G");
        }
        else if (hasYellow && colorCounts[1] == 1 && colorCounts[2] == 3)
        {
            return Resources.Load<Sprite>("SB");
        }
        else if (hasBlue && colorCounts[2] == 3 && colorCounts[0] == 1)
        {
            return Resources.Load<Sprite>("NB");
        }
        else if (hasBlue && colorCounts[2] == 2 && colorCounts[0] == 2)
        {
            return Resources.Load<Sprite>("P");
        }
        else if (hasBlue && colorCounts[2] == 1 && colorCounts[0] == 3)
        {
            return Resources.Load<Sprite>("V");
        }
    return Resources.Load<Sprite>("M");
}

    private Sprite GetRandomTargetColorSprite()
    {
        string[] colorNames = new string[]
        {
            "R", "BO", "O", "SY", "Y", "SG", "G", "SB", "BB", "NB", "P", "V", "B"
        };

        int randomIndex = Random.Range(0, colorNames.Length);
        return Resources.Load<Sprite>(colorNames[randomIndex]);
    }

    public void LoseLife()
    {
        lives--; // Decrease the number of lives
        UpdateLivesText(); // Update the lives text

        if (lives <= 0)
        {
            ShowPlayAgainMenu(); // Show the Play Again menu if no lives left
        }
    }

    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
}