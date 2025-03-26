using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;      // Assign your BirdEnemy prefab in the Inspector
    public float spawnInterval = 5f;   // Time in seconds between spawns
    public Transform[] spawnPoints;    // Optional: array of possible spawn locations

    void Start()
    {
        InvokeRepeating("SpawnBird", 0f, spawnInterval);
    }

    void SpawnBird()
    {
        // Pick a random spawn point if available
        Vector3 spawnPosition = transform.position;
        if (spawnPoints != null && spawnPoints.Length > 0)
        {
            int index = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[index].position;
        }

        Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
    }
}

