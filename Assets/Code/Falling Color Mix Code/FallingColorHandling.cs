using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingColorHandling : MonoBehaviour
{
    public SpriteRenderer targetColorRenderer; 
    public SpriteRenderer resultRenderer;

    public GameObject congratulationsMessage; 

    private Sprite targetColorSprite; 
    private Sprite resultSprite;

    private int[] lastColor = new int[4];
    private int lastIndex = 0;

    private void Start()
    {
        targetColorSprite = GetRandomTargetColorSprite();
        targetColorRenderer.sprite = targetColorSprite;
        resultSprite = Resources.Load<Sprite>("W");
        resultRenderer.sprite = resultSprite;
         congratulationsMessage.SetActive(false);
    }

    public void IncrementRedCount()
    {
        UpdateLastColor(1);
        UpdateResultColor();
        CheckWinCondition();
    }

    public void IncrementYellowCount()
    {
        UpdateLastColor(2);
        UpdateResultColor();
        CheckWinCondition();
    }

    public void IncrementBlueCount()
    {
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

    private void UpdateResultColor()
    {
        resultSprite = GetResultColor();
        resultRenderer.sprite = resultSprite;
    }

    private void CheckWinCondition()
    {
        if (resultSprite == targetColorSprite)
        {
            Debug.Log("Congratulations! You've matched the target color.");
            congratulationsMessage.SetActive(true);
        }
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
}