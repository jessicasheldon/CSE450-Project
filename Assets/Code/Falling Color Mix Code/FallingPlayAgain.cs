using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingPlayAgain : MonoBehaviour
{
    public FallingColorHandling FallingColorHandlingScript ;

    public void OnMouseDown()
    {
         Debug.Log("PlayAgain Clicked");
        
        FallingColorHandlingScript.PlayAgain();
    }
}
