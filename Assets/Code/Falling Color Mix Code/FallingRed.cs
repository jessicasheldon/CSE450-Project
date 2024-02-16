using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRed : MonoBehaviour
{
    public FallingColorHandling colorHandlingScript;

    private void OnCollisionEnter2D()
    {
        colorHandlingScript.IncrementRedCount();
    }
}