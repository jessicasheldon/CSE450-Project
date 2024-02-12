using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysMovementFour : MonoBehaviour
{
    private int currentPosition = 2; // Assuming start in the second section for 0-based indexing

    // Hardcoded positions for the middle of each of the four sections
    private float[] positions = new float[] { -7.5f, -2.5f, 2.5f, 7.5f };

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
