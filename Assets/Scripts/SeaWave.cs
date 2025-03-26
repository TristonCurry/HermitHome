using UnityEngine;

public class SeaWave : MonoBehaviour
{
    [Header("Wave Settings")]
    public float waveSpeed = 5f; // How fast the wave moves
    public float waveForce = 10f; // Force applied to objects
    public float waveDuration = 3f; // How long the wave lasts

    [Header("Wave Sprite")]
    public GameObject waveSprite; // Assign the wave sprite in Inspector (if needed)

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Destroy(gameObject, waveDuration); // Destroy wave after time
    }

    void Update()
    {
        // Move the wave to the left (from right to left)
        transform.Translate(Vector2.left * waveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Debug log to check what is colliding
        Debug.Log("Collided with: " + other.gameObject.name + " Tag: " + other.CompareTag("Player"));

        // Only apply force to food and shells, not the player
        if ((other.CompareTag("food") || other.CompareTag("shell")) && !other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.left * waveForce; // Push item backward
            }
        }
    }
}


