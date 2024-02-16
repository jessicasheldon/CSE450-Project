using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlue : MonoBehaviour
{
    public FallingColorHandling colorHandlingScript;

    private void OnCollisionEnter2D()
    {
        colorHandlingScript.IncrementBlueCount();
    }
}