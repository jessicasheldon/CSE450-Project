using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHandling : MonoBehaviour
{
    private int redCount = 0;
    private int yellowCount = 0;
    private int blueCount = 0;
    private int clickCount = 0;
    private int[] lastColor = new int[4];

    public SpriteRenderer resultRenderer;

    public void IncrementRedCount()
    {
        redCount++;
        Debug.Log( redCount + blueCount + yellowCount);
        if((redCount + yellowCount + blueCount)>4){
            int oldestColor = lastColor[clickCount%4];
            Debug.Log("oldest color: " + oldestColor);
            lastColor[clickCount%4] = 1;
            if (oldestColor == 1){
                redCount--;
            }
            else if (oldestColor == 2){
                yellowCount--;
            }
            else if (oldestColor == 3){
                blueCount--;
            }
        }
        clickCount++;
        Debug.Log("Red count: " + redCount + "Blue count: " + blueCount + "Yellow count: " + yellowCount);
        UpdateResultColor();
    }

    public void IncrementYellowCount()
    {
        yellowCount++;
        if((redCount + yellowCount + blueCount)>4){
            int oldestColor = lastColor[clickCount%4];
            Debug.Log("oldest color: " + oldestColor);
            lastColor[clickCount%4] = 2;
            if (oldestColor == 1){
                redCount--;
            }
            else if (oldestColor == 2){
                yellowCount--;
            }
            else if (oldestColor == 3){
                blueCount--;
            }
        }
        clickCount++;
        Debug.Log("Red count: " + redCount + "Blue count: " + blueCount + "Yellow count: " + yellowCount);
        UpdateResultColor();
    }

    public void IncrementBlueCount()
    {
        blueCount++;
        if((redCount + yellowCount + blueCount)>4){
            int oldestColor = lastColor[clickCount%4];
            Debug.Log("oldest color: " + oldestColor);
            lastColor[clickCount%4] = 3;
            if (oldestColor == 1){
                redCount--;
            }
            else if (oldestColor == 2){
                yellowCount--;
            }
            else if (oldestColor == 3){
                blueCount--;
            }
        }
        clickCount++;
        Debug.Log("Red count: " + redCount + "Blue count: " + blueCount + "Yellow count: " + yellowCount);
        UpdateResultColor();
    }

    private void UpdateResultColor()
    {
        Debug.Log("Updating result color...");
        // Call GetResultColor to determine the correct color
        Sprite colorSprite = GetResultColor();

        // Render the resulting color sprite
        resultRenderer.sprite = colorSprite;
    }

    private Sprite GetResultColor()
    {
        Debug.Log("Getting result color...");
        // Determine the resulting color based on the number of red, yellow, and blue picks
        if( redCount > 1 && blueCount > 1 && yellowCount > 1){
            return Resources.Load<Sprite>("B");
        }
        else if (redCount == 4)
        {
            Debug.Log("Result color: Red");
            return Resources.Load<Sprite>("R");
        }
        else if (redCount == 3 && yellowCount == 1)
        {
            Debug.Log("Result color: Blood Orange");
            return Resources.Load<Sprite>("BO");
        }
        else if (redCount == 2 && yellowCount == 2)
        {
            Debug.Log("Result color: Orange");
            return Resources.Load<Sprite>("O");
        }
        else if (redCount == 1 && yellowCount == 3)
        {
            Debug.Log("Result color: Sunshine Yellow");
            return Resources.Load<Sprite>("SY");
        }
        else if (yellowCount == 4)
        {
            Debug.Log("Result color: Yellow");
            return Resources.Load<Sprite>("Y");
        }
        else if (yellowCount == 3 && blueCount == 1)
        {
            Debug.Log("Result color: Lime Green");
            return Resources.Load<Sprite>("SG");
        }
        else if (yellowCount == 2 && blueCount == 2)
        {
            Debug.Log("Result color: Green");
            return Resources.Load<Sprite>("G");
        }
        else if (yellowCount == 1 && blueCount == 3)
        {
            Debug.Log("Result color: Sea Blue");
            return Resources.Load<Sprite>("SB");
        }
        else if (blueCount == 4)
        {
            Debug.Log("Result color: Bright Blue");
            return Resources.Load<Sprite>("BB");
        }
        else if (blueCount == 3 && redCount == 1) 
        {
            Debug.Log("Result color: Navy Blue");
            return Resources.Load<Sprite>("NB");
        }
        else if (blueCount == 2 && redCount == 2) 
        {
            Debug.Log("Result color: Purple");
            return Resources.Load<Sprite>("P");
        }
        else if (blueCount == 1 && redCount == 3) 
        {
            Debug.Log("Result color: Violet");
            return Resources.Load<Sprite>("V");
        }
        else
        {
            Debug.Log("Result color: Default");
            return Resources.Load<Sprite>("B");
        }
    }
}
