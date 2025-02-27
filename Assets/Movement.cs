using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get movement input
        moveInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Move the hermit crab
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}
