using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public delegate void CollisionWithPlayer();
    public static event CollisionWithPlayer OnPlayerCollision;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision?.Invoke();

            Destroy(gameObject);

            Time.timeScale = 0;
        }

        //Destroy(gameObject);

    }
}
