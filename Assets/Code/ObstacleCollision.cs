using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private CameraShake cameraShake; 
    public delegate void CollisionWithPlayer();
    public static event CollisionWithPlayer OnPlayerCollision;

    public void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>(); 
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraShake.Shake();

            //OnPlayerCollision?.Invoke();

            FindObjectOfType<FallingColorHandling>().LoseLife();

            Destroy(gameObject);
    
            //Time.timeScale = 0;
        }

       

    }
}
