using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private CameraShake cameraShake; 
    public delegate void CollisionWithPlayer();
    public static event CollisionWithPlayer OnPlayerCollision;
    private Code.Collision forceScript;

    public void Start()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        forceScript = FindObjectOfType<Code.Collision>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            cameraShake.Shake();

            //OnPlayerCollision?.Invoke();
            if (forceScript.force)
            {
                print("Force Field active");
            }
            else
            {
                FindObjectOfType<FallingColorHandling>().LoseLife();
            }

            Destroy(gameObject);

            //Time.timeScale = 0;
        }
        

    }
}
