using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPlacement
{
    public class ColorPlacement : MonoBehaviour
    {

        public GameObject redPrefab;
        public GameObject bluePrefab;
        public GameObject yellowPrefab;

        private void Start()
        {
            SpawnRandomColors();
        }

        public void SpawnRandomColors()
        {
            
            StartCoroutine(RandomPosition());

            
        }

        public IEnumerator RandomPosition()
        {
            
            yield return new WaitForSeconds(1.8f);

            float xColorPosition = Random.Range(-8, 8);
            float yColorPosition = Random.Range(7, 12);
            float zColorPosition = 0;

            Vector3 newColorPosition = new(xColorPosition, yColorPosition, zColorPosition);

            int color = Random.Range(1, 4);
            Debug.Log("Color" + color);

            if (color == 1)
            {
                Instantiate(redPrefab, newColorPosition, Quaternion.identity);
            }
            if (color == 2)
            {
                Instantiate(bluePrefab, newColorPosition, Quaternion.identity);
            }
            if (color == 3)
            {
                Instantiate(yellowPrefab, newColorPosition, Quaternion.identity);
            }


        }
            
            
        
    }
}

