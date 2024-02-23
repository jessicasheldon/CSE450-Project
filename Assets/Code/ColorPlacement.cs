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

        private void Start()
        {
            StartCoroutine(SpawnRandomObjects());
        }

        IEnumerator SpawnRandomObjects()
        {

            while (true) {
                yield return new WaitForSeconds(3f);
                RandomColorPosition();
            }



        }

        public void RandomColorPosition()
        {

            

            float xColorPosition = Random.Range(-8, 8);
            float yColorPosition = Random.Range(7, 12);
            float zColorPosition = 0;

            Vector3 newColorPosition = new(xColorPosition, yColorPosition, zColorPosition);

            int color = Random.Range(1, 4);
            Debug.Log("Color spawned" + color);

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



    }
}