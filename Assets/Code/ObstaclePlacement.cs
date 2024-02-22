using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPlacement
{
    public class ObstaclePlacement : MonoBehaviour
    {

        public GameObject TNTPrefab;
        public GameObject spikeBallPrefab;
        public GameObject weightPrefab;

        private void Start()
        {
            SpawnRandomObjects();
        }

        public void SpawnRandomObjects()
        {

            StartCoroutine(RandomObstaclePosition());


        }

        IEnumerator RandomObstaclePosition()
        {

            yield return new WaitForSeconds(1.8f);

            float xObstaclePosition = Random.Range(-8, 8);
            float yObstaclePosition = Random.Range(7, 12);
            float zObstaclePosition = 0;

            Vector3 newObstaclePosition = new(xObstaclePosition, yObstaclePosition, zObstaclePosition);

            int obstacle = Random.Range(1, 4);
            Debug.Log("Obstacle" + obstacle);

            if (obstacle == 1)
            {
                Instantiate(TNTPrefab, newObstaclePosition, Quaternion.identity);
            }
            if (obstacle == 2)
            {
                Instantiate(spikeBallPrefab, newObstaclePosition, Quaternion.identity);
            }
            if (obstacle == 3)
            {
                Instantiate(weightPrefab, newObstaclePosition, Quaternion.identity);
            }
            

        }



    }
}
