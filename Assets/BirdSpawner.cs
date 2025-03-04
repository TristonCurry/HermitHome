using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab; // Assign the BirdEnemy prefab
    public AudioClip warningSound; // Assign a warning sound clip

    public float minSpawnTime = 60f; // 1 minute
    public float maxSpawnTime = 300f; // 5 minutes

    public float spawnHeight = 5f; // How high the bird spawns above the player

    private Transform player;
    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SpawnBirdRoutine());
    }

    IEnumerator SpawnBirdRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime); // Random time between 1-5 minutes
            yield return new WaitForSeconds(waitTime - 15f); // Wait until 6 seconds before spawn

            // Play warning sound 6 seconds before the bird appears
            if (audioSource != null && warningSound != null)
            {
                audioSource.PlayOneShot(warningSound);
            }

            yield return new WaitForSeconds(6f); // Wait for 6 seconds after warning sound

            // Spawn the bird
            if (player != null && birdPrefab != null)
            {
                Vector3 spawnPosition = new Vector3(player.position.x, player.position.y + spawnHeight, 0);
                Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
