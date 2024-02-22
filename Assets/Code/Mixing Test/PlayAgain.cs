using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgainButton : MonoBehaviour
{
    public ColorHandling colorHandlingScript;

    private void OnMouseDown()
    {
        Debug.Log("PlayAgain Clicked");
        
        colorHandlingScript.PlayAgain();
    }
}