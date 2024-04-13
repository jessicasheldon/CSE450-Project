using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class ColorPlacement : MonoBehaviour
    {

        public GameObject red;
        public GameObject blue;
        public GameObject yellow;
        public GameObject black;
        public GameObject white;
        public GameObject water;
        public GameObject forceField;
        public GameObject star;
        public GameObject doubleSpeed;
        private GameObject newObject;

        private int delay = 5;
     

        private FallingColorHandling fallingColorHandling;
        private Collision collisionScript;

        private void Start()
        {
            fallingColorHandling = FindObjectOfType<FallingColorHandling>();
            collisionScript = FindObjectOfType<Collision>();
            StartCoroutine(SpawnRandomObjects());
        }

        

        IEnumerator SpawnRandomObjects()
        {
            int loops = 0;
            while (true)
            {
                if (fallingColorHandling.shouldObjectsSpawn())
                    {
                        Debug.Log(loops%delay);
                        if(loops%delay == 4){
                            yield return new WaitForSeconds(1f);
                            RandomPowerUpPosition();
                        }
                        else{
                            yield return new WaitForSeconds(3f);
                            RandomColorPosition();
                        }
                    loops += 1;
                }
                else
                {
                        yield return new WaitForSeconds(0.5f);
                }
            }
        }

        public void RandomColorPosition()
        {
            float xColorPosition = Random.Range(-8, 8);
            float yColorPosition = Random.Range(7, 12);
            float zColorPosition = 0;

            Vector3 newColorPosition = new(xColorPosition, yColorPosition, zColorPosition);

            int color = Random.Range(1, 6);

            if (color == 1)
            {
                newObject = Instantiate(red, newColorPosition, Quaternion.identity);
            }
            if (color == 2)
            {
                newObject = Instantiate(yellow, newColorPosition, Quaternion.identity);
            }
            if (color == 3)
            {
               newObject = Instantiate(blue, newColorPosition, Quaternion.identity);
            }
            if (color == 4)
            {
                newObject = Instantiate(white, newColorPosition, Quaternion.identity);
            }
            if (color == 5)
            {
                newObject = Instantiate(black, newColorPosition, Quaternion.identity);
            }

            if (collisionScript != null && collisionScript.speed)
            {
                Debug.Log("Gravity adjusted color");
                Rigidbody2D gravity = newObject.GetComponent<Rigidbody2D>();
                gravity.gravityScale *= 2;
            }
            

        }


        public void ClearObjects()
        {
            GameObject[] colorObjects = GameObject.FindGameObjectsWithTag("Color");
            foreach (GameObject colorObject in colorObjects)
            {
                Destroy(colorObject);
            }

            GameObject[] powerUpObjects = GameObject.FindGameObjectsWithTag("PowerUp");
            foreach (GameObject powerUpObject in powerUpObjects)
            {
                Destroy(powerUpObject);
            }
        }

        public void RandomPowerUpPosition()
        {
            float xPowerPosition = Random.Range(-8, 8);
            float yPowerPosition = Random.Range(7, 12);
            float zPowerPosition = 0;

            int powerUp = Random.Range(1, 5);

            Vector3 newPowerPosition = new(xPowerPosition, yPowerPosition, zPowerPosition);

            if (powerUp == 1)
            {
                newObject = Instantiate(water, newPowerPosition, Quaternion.identity);
            }
            if (powerUp == 2)
            {
                newObject = Instantiate(forceField, newPowerPosition, Quaternion.identity);
            }
            if (powerUp == 3)
            {
                newObject = Instantiate(star, newPowerPosition, Quaternion.identity);
            }
            if (powerUp == 4)
            {
                newObject = Instantiate(doubleSpeed, newPowerPosition, Quaternion.identity);
            }

            if (collisionScript != null && collisionScript.speed)
            {
                Debug.Log("Gravity adjusted powerup");
                Rigidbody2D gravity = newObject.GetComponent<Rigidbody2D>();
                gravity.gravityScale *= 2;
            }
        }



    }
}