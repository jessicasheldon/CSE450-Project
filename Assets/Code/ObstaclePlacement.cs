using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPlacement
{
    public class ObstaclePlacement : MonoBehaviour
    {

        public GameObject obstaclePrefab;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                randomPosition();

            }
        }

        public void randomPosition()
        {

            int xObstaclePosition = Random.Range(-10, 10);
            int yObstaclePosition = Random.Range(10, 20);
            int zObstaclePosition = Random.Range(-10, 10);

            Vector3 newObstaclePosition = new Vector3(xObstaclePosition, yObstaclePosition, zObstaclePosition);

            Instantiate(obstaclePrefab, newObstaclePosition, Quaternion.identity);


        }



    }
}
