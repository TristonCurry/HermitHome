using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject wavePrefab;  // The SeaWave prefab to spawn
    public Transform cameraTransform;  // Assign this manually or it will auto-assign to the Main Camera

    private float minSpawnTime = 60f;  // 3 minutes
    private float maxSpawnTime = 300f;  // 5 minutes
    private float spawnOffset = 10f;  // Distance from the camera's right edge

    void Start()
    {
        // Automatically assign the Main Camera if the cameraTransform is not set in the Inspector
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        // Schedule the first wave to spawn
        ScheduleNextWave();
    }

    void SpawnWave()
    {
        // Determine the spawn position relative to the camera's position
        Vector3 spawnPosition = new Vector3(cameraTransform.position.x + spawnOffset, cameraTransform.position.y, 0);
        
        // Instantiate the wave prefab at the spawn position
        Instantiate(wavePrefab, spawnPosition, Quaternion.identity);
        
        // Schedule the next wave
        ScheduleNextWave();
    }

    void ScheduleNextWave()
    {
        // Get a random spawn time between the min and max intervals
        float nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        
        // Invoke the SpawnWave method after the random interval
        Invoke(nameof(SpawnWave), nextSpawnTime);
    }
}

