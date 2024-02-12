using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMovement : MonoBehaviour
{
    private int currentPosition = 1; // Start in the middle position, adjusted to 1 for 0-based indexing

    // Hardcoded positions for the middle of each third
    private float[] positions = new float[] { -5.9f, 0f, 5.9f };

    void Update()
    {
        // Move left with A key
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        // Move right with D key
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        // Check if not at the leftmost position
        if (currentPosition > 0)
        {
            currentPosition--;
            MoveToPosition();
        }
    }

    void MoveRight()
    {
        // Check if not at the rightmost position
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
        // Adjust Y and Z based on your game's requirements
        transform.position = newPosition;
    }
}
