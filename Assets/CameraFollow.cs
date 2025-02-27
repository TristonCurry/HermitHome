using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public float smoothSpeed = 5f; // Speed of camera movement
    public Vector3 offset; // Offset from the player

    void Start()
    {
        // Find the player by tag if not assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Smoothly move the camera towards the target position
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
