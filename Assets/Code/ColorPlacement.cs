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

        private int delay = 5;

        private FallingColorHandling fallingColorHandling;

        private void Start()
        {
            fallingColorHandling = FindObjectOfType<FallingColorHandling>();
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



        public void RandomPowerUpPosition()
        {
            float xPowerPosition = Random.Range(-8, 8);
            float yPowerPosition = Random.Range(7, 12);
            float zPowerPosition = 0;

            Vector3 newPowerPosition = new(xPowerPosition, yPowerPosition, zPowerPosition);

            Instantiate(water, newPowerPosition, Quaternion.identity);

        }



    }
}