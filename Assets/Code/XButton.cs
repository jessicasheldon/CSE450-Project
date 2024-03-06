using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xButton : MonoBehaviour
{
    public FallingColorHandling FallingColorHandling;

    private void OnMouseDown()
    {        
        FallingColorHandling.HideTutorialScreen();
    }
}