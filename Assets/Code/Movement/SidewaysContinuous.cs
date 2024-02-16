using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysContinuous : MonoBehaviour
{
    public float speed = 5.0f;
    public float minX = -7.0f; // Left boundary
    public float maxX = 7.0f;  // Right boundary

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveAmount = horizontalInput * speed * Time.deltaTime;

        // Calculate the new position with the movement applied
        float newXPosition = transform.position.x + moveAmount;

        // Clamp the new position within the boundaries
        newXPosition = Mathf.Clamp(newXPosition, minX, maxX);

        // Apply the clamped position to the transform
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
