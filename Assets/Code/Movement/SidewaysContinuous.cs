using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysContinuous : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    public float minX = -9.0f; // Left boundary
    public float maxX = 9.0f;  // Right boundary
    private bool isGrounded;
    private Rigidbody2D _rb;
    public KeyCode jump = KeyCode.Space;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

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

        if (Input.GetKeyDown(jump) && isGrounded) 
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }


    // Detect collision with the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))  // Ensure the ground has the tag "Ground"
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
