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
        public GameObject water;
        public GameObject forceField;

        private int delay = 5;
        private int count = 0;
        Collision forceScript;

        private FallingColorHandling fallingColorHandling;

        private void Start()
        {
            fallingColorHandling = FindObjectOfType<FallingColorHandling>();
            forceScript = FindObjectOfType<Collision>();
            StartCoroutine(SpawnRandomObjects());
        }

        private void Update()
        {
            if (count == 50)
            {
                count = 0;
                forceScript.force = false;
            }

            if (forceScript.force == true)
            {

                forceField.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                forceField.transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
                
            }

            
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

            int color = Random.Range(1, 4);

            if (color == 1)
            {
                Instantiate(red, newColorPosition, Quaternion.identity);
            }
            if (color == 2)
            {
                Instantiate(yellow, newColorPosition, Quaternion.identity);
            }
            if (color == 3)
            {
                Instantiate(blue, newColorPosition, Quaternion.identity);
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

            int powerUp = Random.Range(1, 3);

            Vector3 newPowerPosition = new(xPowerPosition, yPowerPosition, zPowerPosition);

            if (powerUp == 1)
            {
                Instantiate(water, newPowerPosition, Quaternion.identity);
            }
            if (powerUp == 2)
            {
                Instantiate(forceField, newPowerPosition, Quaternion.identity);
            }
            

        }



    }
}