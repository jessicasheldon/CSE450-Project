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

    public SpriteRenderer mix1;
    public SpriteRenderer mix2;
    public SpriteRenderer mix3; 
    public SpriteRenderer mix4;
    public SpriteRenderer mix5; 
    
    public GameObject congratulationsMessage; 
    public GameObject playAgainButton;

    private Sprite targetColorSprite; 
    private Sprite resultSprite;

    public GameObject tutorialScreen;
    public GameObject xButton;

    private int[] lastColor = new int[4];
    private int[] lastShade = new int[2];
    private int lastColorIndex = 0;
    private int lastShadeIndex = 0;

    private bool objectsSpawning = false;
    private Code.ObstaclePlacement obstaclePlacement;
    public SpriteRenderer spriteRenderer;
    private Color originalColor = Color.white;

    private int score = 0;
    public Text scoreText;
    private int stage = 1;
    public Text stageText;

    private int lives = 3;
    public Text livesText;

    private bool isInvincible = false;
    public float invincibilityDuration = 5f;

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
        loadMixSprite(targetColorSprite); 
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

    public void IncrementWhiteCount()
    {
        UpdateScore(10);
        UpdateLastShade(1);
        UpdateResultColor();
        CheckWinCondition();
    }

    public void IncrementBlackCount()
    {
        Debug.Log("increment black");
        UpdateScore(10);
        UpdateLastShade(2);
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

        lastColor[lastColorIndex] = color;
        lastColorIndex = (lastColorIndex + 1) % 4;
    }

    private void UpdateLastShade(int shade)
    {
        if (lastShade[0] == 0)
        {
            for (int i = 0; i < 2; i++)
            {
                lastShade[i] = shade;
            }
            return;
        }

        lastShade[lastShadeIndex] = shade;
        lastShadeIndex = (lastShadeIndex + 1) % 2;
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
    for (int i = 0; i < 2; i++)
    {
        lastShade[i] = 0;
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
            loadMixSprite(targetColorSprite); 
            // Reset the result color to white
            resultSprite = Resources.Load<Sprite>("W");
            resultRenderer.sprite = resultSprite;
            // Reset the lastColor array
            for (int i = 0; i < 4; i++)
            {
                lastColor[i] = 0;
            }
            for (int j = 0; j < 2; j++)
            {
                lastColor[j] = 0;
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
        loadMixSprite(targetColorSprite); 
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


    public void Pause(){
        objectsSpawning = false;
    }

    public void StartAgain(){
        objectsSpawning = true;
    }


private Sprite GetResultColor()
{
    int[] colorCounts = new int[4];
    int[] shadeCounts = new int[2];
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

    bool hasWhite = false;
    bool hasBlack = false;

    for (int i = 0; i < 2; i++)
    {
        if (lastShade[i] == 1)
        {
            hasWhite = true;
        }
        else if(lastShade[i] == 2){
            hasBlack = true;
        }
    }

    Debug.Log("has white: " + hasWhite);
    Debug.Log("has black: " + hasBlack);

    int shadeVariant = 0;

    if((hasWhite && hasBlack) || (!hasBlack && !hasWhite)){
        shadeVariant = 0;
    }
    else if(hasWhite && !hasBlack){
        shadeVariant = 1;
    }
    else{
        shadeVariant = 2;
    }

    Debug.Log("shade variant: " + shadeVariant);

    // Check if at least two colors are present to determine the resulting color
        if (hasRed && hasYellow && hasBlue)
        {
            return Resources.Load<Sprite>("B");
        }
        else if (hasRed && colorCounts[0] == 4)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("R");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LR");
            }
            else{
                return Resources.Load<Sprite>("DR");
            }
        }
        else if (hasYellow && colorCounts[1] == 4)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("Y");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LY");
            }
            else{
                return Resources.Load<Sprite>("DY");
            }
        }
        else if (hasBlue && colorCounts[2] == 4)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("BB");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LBB");
            }
            else{
                return Resources.Load<Sprite>("DBB");
            }
        }
        else if (hasRed && colorCounts[0] == 3 && colorCounts[1] == 1)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("BO");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LBO");
            }
            else{
                return Resources.Load<Sprite>("DBO");
            }
        }
        else if (hasRed && colorCounts[0] == 2 && colorCounts[1] == 2)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("O");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LO");
            }
            else{
                return Resources.Load<Sprite>("DO");
            }
        }
        else if (hasRed && colorCounts[0] == 1 && colorCounts[1] == 3)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("SY");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LSY");
            }
            else{
                return Resources.Load<Sprite>("DSY");
            }

        }
        else if (hasYellow && colorCounts[1] == 3 && colorCounts[2] == 1)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("SG");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LSG");
            }
            else{
                return Resources.Load<Sprite>("DSG");
            }
        }
        else if (hasYellow && colorCounts[1] == 2 && colorCounts[2] == 2)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("G");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LG");
            }
            else{
                return Resources.Load<Sprite>("DG");
            }
        }
        else if (hasYellow && colorCounts[1] == 1 && colorCounts[2] == 3)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("SB");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LSB");
            }
            else{
                return Resources.Load<Sprite>("DSB");
            }

        }
        else if (hasBlue && colorCounts[2] == 3 && colorCounts[0] == 1)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("NB");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LNB");
            }
            else{
                return Resources.Load<Sprite>("DNB");
            }
        }
        else if (hasBlue && colorCounts[2] == 2 && colorCounts[0] == 2)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("P");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LP");
            }
            else{
                return Resources.Load<Sprite>("DP");
            }
        }
        else if (hasBlue && colorCounts[2] == 1 && colorCounts[0] == 3)
        {
            if(shadeVariant == 0){
                return Resources.Load<Sprite>("V");
            } 
            else if(shadeVariant == 1){
                return Resources.Load<Sprite>("LV");
            }
            else{
                return Resources.Load<Sprite>("DV");
            }
        }
    return Resources.Load<Sprite>("M");
}

    private Sprite GetRandomTargetColorSprite()
    {
        string[] colorNames = new string[]
        {
            "R", "BO", "O", "SY", "Y", "SG", "G", "SB", "BB", "NB", "P", "V", "B",
            "LR", "LBO", "LO", "LSY", "LY", "LSG", "LG", "LSB", "LBB", "LNB", "LP", "LV", "LB",
            "DR", "DBO", "DO", "DSY", "DY", "DSG", "DG", "DSB", "DBB", "DNB", "DP", "DV", "DB"
        };

        int randomIndex = Random.Range(0, colorNames.Length);
        return Resources.Load<Sprite>(colorNames[randomIndex]);
    }

    private void loadMixSprite(Sprite target)
    {
        if (target == Resources.Load<Sprite>("B"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("Y");
            mix3.sprite = Resources.Load<Sprite>("BB");
            mix4.sprite = Resources.Load<Sprite>("B");
            if (target == Resources.Load<Sprite>("LB"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DB"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("R") || target == Resources.Load<Sprite>("LR") ||
                 target == Resources.Load<Sprite>("DR"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("R");
            mix3.sprite = Resources.Load<Sprite>("R");
            mix4.sprite = Resources.Load<Sprite>("R");
            if (target == Resources.Load<Sprite>("LR"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DR"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }else if (target == Resources.Load<Sprite>("Y") || target == Resources.Load<Sprite>("LY") ||
                  target == Resources.Load<Sprite>("DY"))
        {
            mix1.sprite = Resources.Load<Sprite>("Y");
            mix2.sprite = Resources.Load<Sprite>("Y");
            mix3.sprite = Resources.Load<Sprite>("Y");
            mix4.sprite = Resources.Load<Sprite>("Y");
            if (target == Resources.Load<Sprite>("LY"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DY"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }else if (target == Resources.Load<Sprite>("BB") || target == Resources.Load<Sprite>("LBB") ||
                  target == Resources.Load<Sprite>("DBB"))
        {
            mix1.sprite = Resources.Load<Sprite>("BB");
            mix2.sprite = Resources.Load<Sprite>("BB");
            mix3.sprite = Resources.Load<Sprite>("BB");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LBB"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DVBB"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("BO") || target == Resources.Load<Sprite>("LBO") ||
                 target == Resources.Load<Sprite>("DBO"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("R");
            mix3.sprite = Resources.Load<Sprite>("R");
            mix4.sprite = Resources.Load<Sprite>("Y");
            if (target == Resources.Load<Sprite>("LBO"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DBO"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("O") || target == Resources.Load<Sprite>("LO") ||
                 target == Resources.Load<Sprite>("DO"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("R");
            mix3.sprite = Resources.Load<Sprite>("Y");
            mix4.sprite = Resources.Load<Sprite>("Y");
            if (target == Resources.Load<Sprite>("LO"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DO"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("SY") || target == Resources.Load<Sprite>("LSY") ||
                 target == Resources.Load<Sprite>("DSY"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("Y");
            mix3.sprite = Resources.Load<Sprite>("Y");
            mix4.sprite = Resources.Load<Sprite>("Y");
            if (target == Resources.Load<Sprite>("LSY"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DSY"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("SG") || target == Resources.Load<Sprite>("LSG") ||
                 target == Resources.Load<Sprite>("DSG"))
        {
            mix1.sprite = Resources.Load<Sprite>("Y");
            mix2.sprite = Resources.Load<Sprite>("Y");
            mix3.sprite = Resources.Load<Sprite>("Y");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LSG"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DSG"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("G") || target == Resources.Load<Sprite>("LG") ||
                 target == Resources.Load<Sprite>("DG"))
        {
            mix1.sprite = Resources.Load<Sprite>("Y");
            mix2.sprite = Resources.Load<Sprite>("Y");
            mix3.sprite = Resources.Load<Sprite>("BB");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LG"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DG"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("SB") || target == Resources.Load<Sprite>("LSB") ||
                 target == Resources.Load<Sprite>("DSB"))
        {
            mix1.sprite = Resources.Load<Sprite>("Y");
            mix2.sprite = Resources.Load<Sprite>("BB");
            mix3.sprite = Resources.Load<Sprite>("BB");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LSB"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DSB"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("NB") || target == Resources.Load<Sprite>("LNB") ||
                 target == Resources.Load<Sprite>("DNB"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("BB");
            mix3.sprite = Resources.Load<Sprite>("BB");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LNB"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DNB"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("P") || target == Resources.Load<Sprite>("LP") ||
                 target == Resources.Load<Sprite>("DP"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("R");
            mix3.sprite = Resources.Load<Sprite>("BB");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LP"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DP"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
        else if (target == Resources.Load<Sprite>("V") || target == Resources.Load<Sprite>("LV") ||
                 target == Resources.Load<Sprite>("DV"))
        {
            mix1.sprite = Resources.Load<Sprite>("R");
            mix2.sprite = Resources.Load<Sprite>("R");
            mix3.sprite = Resources.Load<Sprite>("R");
            mix4.sprite = Resources.Load<Sprite>("BB");
            if (target == Resources.Load<Sprite>("LV"))
            {
                mix5.sprite = Resources.Load<Sprite>("W"); 
            }
            else if (target == Resources.Load<Sprite>("DV"))
            {
                mix5.sprite = Resources.Load<Sprite>("Black");
            }
            else
            {
                mix5.sprite = Resources.Load<Sprite>("B");
            }
        }
         
    }

    private IEnumerator RainbowEffectCoroutine(float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            // Calculate the progress (0 to 1) over time
            float progress = elapsedTime / duration;

            // Interpolate between rainbow colors based on progress
            spriteRenderer.color = RainbowLerp(progress);

            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until next frame
            yield return null;
        }

        // Revert to the original color
        spriteRenderer.color = originalColor;
    }
    private Color RainbowLerp(float progress)
    {
        // Define colors of the rainbow
        Color[] colors = new Color[]
        {
            Color.red,
            Color.yellow,
            Color.green,
            Color.cyan,
            Color.blue,
            Color.magenta,
            Color.red // Repeat red to loop back at the end
        };

        // Calculate which two colors to interpolate between
        int index = (int)(progress * (colors.Length - 1));
        float subProgress = (progress * (colors.Length - 1)) - index;

        // Interpolate between the two colors
        return Color.Lerp(colors[index], colors[index + 1], subProgress);
    }
    public void LoseLife()
    {
        if (!isInvincible)
        {
            lives--; // Decrease the number of lives
            UpdateLivesText(); // Update the lives text

            if (lives <= 0)
            {
                ShowPlayAgainMenu(); // Show the Play Again menu if no lives left
            }
        }
    }
    public void ActivateInvincibility(float duration)
    {
        StartCoroutine(InvincibilityCoroutine(duration));
    }

    private IEnumerator InvincibilityCoroutine(float duration)
    {
        isInvincible = true;
        StartCoroutine(RainbowEffectCoroutine(duration));

        yield return new WaitForSeconds(duration);

        isInvincible = false;
    }
    private void UpdateLivesText()
    {
        livesText.text = "Lives: " + lives;
    }
    public bool IsInvincible
    {
        get { return isInvincible; }
    }
}