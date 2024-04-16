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
        public GameObject sidewaysObstaclePrefab;

        private bool spawnSidewaysObstacle = false;

        private FallingColorHandling fallingColorHandling;

        private float spawnTime = 3.0f;

        private void Start()
        {
            fallingColorHandling = FindObjectOfType<FallingColorHandling>();
            StartCoroutine(SpawnRandomObjects());
        }

        public void UpdateSpawnRate(int currentStage)
        {
            // Reduce the spawn time every 3 stages, but don't let it go below some minimum value
            if (currentStage % 2 == 0)
            {
                spawnTime = Mathf.Max(spawnTime * 0.8f, 0.5f); // Reduce the spawnRate by 80% with minimum 0.5 second.
            }

            if (currentStage >= 5)
            {
                spawnSidewaysObstacle = true;
                // SpawnSidewaysObstacle();
            }
        }


        IEnumerator SpawnRandomObjects()
        {
            while (true)
            {
                if (fallingColorHandling.shouldObjectsSpawn())
                {
                    yield return new WaitForSeconds(spawnTime);
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

            int obstacle = Random.Range(1, 5);
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
            else if (obstacle == 4 && spawnSidewaysObstacle)
            {
                SpawnSidewaysObstacle();
            }
        }

        public void ClearObstacles()
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject obstacle in obstacles)
            {
                Destroy(obstacle);
            }
        }

        private void SpawnSidewaysObstacle()
        {
            // Define the start position for the sideways obstacle, potentially off-screen
            Vector3 startPosition = new Vector3(-10, -4, 0);  // Adjust this position as needed
            GameObject obstacle = Instantiate(sidewaysObstaclePrefab, startPosition, Quaternion.identity);
        }
    }
}