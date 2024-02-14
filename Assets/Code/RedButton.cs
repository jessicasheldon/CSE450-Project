using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public ColorHandling colorHandlingScript;

    private void OnMouseDown()
    {
        colorHandlingScript.IncrementRedCount();
    }
}