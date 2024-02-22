using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{
    public ColorHandling colorHandlingScript;

    private void OnMouseDown()
    {
        colorHandlingScript.IncrementYellowCount();
    }
}