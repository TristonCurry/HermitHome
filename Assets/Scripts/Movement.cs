using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private float moveInputX;
    private float moveInputY;
    private StaminaSystem staminaSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        staminaSystem = GetComponent<StaminaSystem>(); // Get StaminaSystem reference
    }

    void Update()
    {
        // Prevent movement if stamina is depleted
        if (staminaSystem != null && staminaSystem.IsOutOfStamina())
        {
            moveInputX = 0f;
            moveInputY = 0f;
        }
        else
        {
            moveInputX = Input.GetAxis("Horizontal");
            moveInputY = Input.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        // Move the player if they have stamina
        rb.velocity = new Vector2(moveInputX * moveSpeed, moveInputY * moveSpeed);
    }
}
