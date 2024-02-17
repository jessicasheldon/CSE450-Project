using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPlacement
{
    public class ColorPlacement : MonoBehaviour
    {

        public GameObject colorPrefab;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                randomPosition();

            }
        }

        public void randomPosition()
        {

            int xColorPosition = Random.Range(-10, 10);
            int yColorPosition = Random.Range(10, 20);
            int zColorPosition = Random.Range(-10, 10);

            Vector3 newColorPosition = new Vector3(xColorPosition, yColorPosition, zColorPosition);
           

            Instantiate(colorPrefab, newColorPosition, Quaternion.identity);
           
        }
            
            
        
    }
}

