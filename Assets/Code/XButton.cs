using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public FallingColorHandling FallingColorHandling;

    private void OnMouseDown()
    {        
        FallingColorHandling.HideTutorialScreen();
    }
}