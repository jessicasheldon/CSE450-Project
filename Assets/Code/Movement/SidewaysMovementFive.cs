using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMovementFive : MonoBehaviour
{
    private int currentPosition = 2; // Start in the middle section, adjusted for 0-based indexing

    // Hardcoded positions for the middle of each of the five sections
    private float[] positions = new float[] { -9f, -4.5f, 0f, 4.5f, 9f };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        if (currentPosition > 0)
        {
            currentPosition--;
            MoveToPosition();
        }
    }

    void MoveRight()
    {
        if (currentPosition < positions.Length - 1)
        {
            currentPosition++;
            MoveToPosition();
        }
    }

    void MoveToPosition()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = positions[currentPosition];
        transform.position = newPosition;
    }
}
