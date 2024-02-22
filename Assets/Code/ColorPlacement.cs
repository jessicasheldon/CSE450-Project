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
            GameObject newCircle = null;
            if (color == 1)
            {
                newCircle = Instantiate(redPrefab, newColorPosition, Quaternion.identity);
            }
            else if (color == 2)
            {
                newCircle = Instantiate(bluePrefab, newColorPosition, Quaternion.identity);
            }
            else if (color == 3)
            {
                newCircle = Instantiate(yellowPrefab, newColorPosition, Quaternion.identity);
            }

            if (newCircle != null)
            {
                FallingBlue fallingBlueScript = newCircle.GetComponent<FallingBlue>();
                if (fallingBlueScript != null)
                {
                    fallingBlueScript.colorHandlingScript = FindObjectOfType<FallingColorHandling>();
                }
                FallingRed fallingRedScript = newCircle.GetComponent<FallingRed>();
                if (fallingRedScript != null)
                {
                    fallingRedScript.colorHandlingScript = FindObjectOfType<FallingColorHandling>();
                }
                FallingYellow fallingYellowScript = newCircle.GetComponent<FallingYellow>();
                if (fallingRedScript != null)
                {
                    fallingRedScript.colorHandlingScript = FindObjectOfType<FallingColorHandling>();
                }
            }

        }
            
            
        
    }
}

