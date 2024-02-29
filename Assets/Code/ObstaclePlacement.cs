using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class ObstaclePlacement : MonoBehaviour
    {
        public GameObject TNTPrefab;
        public GameObject spikeBallPrefab;
        public GameObject weightPrefab;

        private FallingColorHandling fallingColorHandling;

        private void Start()
        {
            fallingColorHandling = FindObjectOfType<FallingColorHandling>();
            StartCoroutine(SpawnRandomObjects());
        }

        IEnumerator SpawnRandomObjects()
        {
            while (true)
            {
                if (fallingColorHandling.shouldObjectsSpawn())
                {
                    yield return new WaitForSeconds(3f);
                    RandomObstaclePosition();
                }
                else
                {
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
        public void RandomObstaclePosition()
        {
            float xObstaclePosition = Random.Range(-8, 8);
            float yObstaclePosition = Random.Range(7, 12);
            float zObstaclePosition = 0;

            Vector3 newObstaclePosition = new Vector3(xObstaclePosition, yObstaclePosition, zObstaclePosition);

            int obstacle = Random.Range(1, 4);
            if (obstacle == 1)
            {
                Instantiate(TNTPrefab, newObstaclePosition, Quaternion.identity);
            }
            else if (obstacle == 2)
            {
                Instantiate(spikeBallPrefab, newObstaclePosition, Quaternion.identity);
            }
            else if (obstacle == 3)
            {
                Instantiate(weightPrefab, newObstaclePosition, Quaternion.identity);
            }
        }
    }
}