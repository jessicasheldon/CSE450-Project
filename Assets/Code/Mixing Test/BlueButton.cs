using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueButton : MonoBehaviour
{
    public ColorHandling colorHandlingScript;

    private void OnMouseDown()
    {
        colorHandlingScript.IncrementBlueCount();
    }
}