using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] freeObstacles;
    public GameObject[] topObstacles;
    public GameObject[] wallObstacles;
    public GameObject gateObstacle;
    public Transform[] topSpawnPositions;
    public Transform[] freeSpawnPositions;
    public Transform[] wallSpawnPositions;
    public Transform[] gateSpawnPositions;

    void Start()
    {
        SpawnTopObstacles();
        SpawnFreeObstacles();
        SpawnWallObstacles();
        SpawnGate();
    }

    void SpawnTopObstacles()
    {
        foreach (Transform spawnPoint in topSpawnPositions)
        {
            InstantiateRandomObstacle(topObstacles, spawnPoint.position, Quaternion.identity);
        }
    }

    void SpawnFreeObstacles()
{
    foreach (Transform spawnPoint in freeSpawnPositions)
    {
        if (spawnPoint != null)
        {
            Ray ray = new Ray(spawnPoint.position, Vector3.down);

            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                float minHeight = hitInfo.point.y; 
                float maxHeight = minHeight + 20.0f; 

                float randomXPosition = Random.Range(-12.5f, 12.5f);
                float randomYPosition = Random.Range(minHeight, maxHeight);

                InstantiateRandomObstacle(freeObstacles, new Vector3(randomXPosition, randomYPosition, spawnPoint.position.z), Quaternion.identity);
            }
        }
    }
}

    void SpawnWallObstacles()
    {
        foreach (Transform spawnPoint in wallSpawnPositions)
        {
            if (spawnPoint != null)
            {
                InstantiateRandomObstacle(wallObstacles, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    void SpawnGate()
    {
        if (gateSpawnPositions.Length == 0)
        {
            return; 
        }

        float randomYPosition = Random.Range(-100f, 40f);

        Transform spawnPoint = gateSpawnPositions[Random.Range(0, gateSpawnPositions.Length)];

        Instantiate(gateObstacle, new Vector3(spawnPoint.position.x, randomYPosition, spawnPoint.position.z), Quaternion.identity);
    }

    void InstantiateRandomObstacle(GameObject[] obstacleArray, Vector3 position, Quaternion rotation)
    {
        if (obstacleArray.Length > 0)
        {
            int randomObstacleIndex = Random.Range(0, obstacleArray.Length);
            GameObject obstaclePrefab = obstacleArray[randomObstacleIndex];
            Instantiate(obstaclePrefab, position, rotation);
        }
    }
}
