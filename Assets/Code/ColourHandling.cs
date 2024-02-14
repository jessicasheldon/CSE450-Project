using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHandling : MonoBehaviour
{

    private int clickCount = 0;
    private int[] lastColor = new int[4];
    private int lastIndex = 0; 

    public SpriteRenderer resultRenderer;

    public void IncrementRedCount()
    {
        UpdateLastColor(1);
        UpdateResultColor();
    }

    public void IncrementYellowCount()
    {
        UpdateLastColor(2);
        UpdateResultColor();
    }

    public void IncrementBlueCount()
    {
        UpdateLastColor(3);
        UpdateResultColor();
    }

    private void UpdateLastColor(int color)
    {
        lastColor[lastIndex] = color; 
        lastIndex = (lastIndex + 1) % 4;
        clickCount++;
    }

    private void UpdateResultColor()
    {
        Debug.Log("Updating result color...");
        Sprite colorSprite = GetResultColor();
        resultRenderer.sprite = colorSprite;
    }

    private Sprite GetResultColor()
{
    int[] colorCounts = new int[4];
    for (int i = 0; i < 4; i++)
    {
        colorCounts[lastColor[i] - 1]++;
    }

    bool hasRed = colorCounts[0] > 0;
    bool hasYellow = colorCounts[1] > 0;
    bool hasBlue = colorCounts[2] > 0;

    if (hasRed && hasYellow && hasBlue)
    {
        return Resources.Load<Sprite>("B");
    }
    else if (hasRed && colorCounts[0] == 4)
    {
        return Resources.Load<Sprite>("R");
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
    else if (hasYellow && colorCounts[1] == 4)
    {
        return Resources.Load<Sprite>("Y");
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
    else if (hasBlue && colorCounts[2] == 4)
    {
        return Resources.Load<Sprite>("BB");
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
    else
    {
        return Resources.Load<Sprite>("W");
    }
}
}
