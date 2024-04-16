using UnityEngine;

public class SidewaysObstacle : MonoBehaviour
{
    public float minSpeed = 3.0f;     // Minimum speed of the obstacle
    public float maxSpeed = 7.0f;     // Maximum speed of the obstacle
    public float boundary = 10.0f;    // Boundary beyond which the obstacle will be destroyed
    private float speed;
    public float rotationSpeed = -200.0f; 

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        // Move the obstacle to the right each frame
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        // Rotate the obstacle around its local Z-axis at the specified rotation speed
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime, Space.Self);

        // Destroy the obstacle if it moves beyond the boundary
        if (transform.position.x > boundary)
        {
            Destroy(gameObject);
        }
    }
}