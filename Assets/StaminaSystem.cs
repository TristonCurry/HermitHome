using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    [Header("Stamina Settings")]
    public float maxStamina = 100f;
    public float staminaDrainRate = 10f; // Stamina lost per second while moving
    private float currentStamina;

    [Header("UI Elements")]
    public Image staminaBar; // UI image for stamina

    private Movement movementScript;

    void Start()
    {
        currentStamina = maxStamina;
        movementScript = GetComponent<Movement>(); // Get movement script
    }

    void Update()
    {
        bool isMoving = Mathf.Abs(Input.GetAxis("Horizontal")) > 0; // Check if moving

        // Drain stamina when moving
        if (isMoving && currentStamina > 0)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }

        // Update stamina UI
        if (staminaBar != null)
        {
            staminaBar.fillAmount = currentStamina / maxStamina;
        }
    }

    public void RefillStamina(float amount)
    {
        currentStamina += amount;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("food")) // Check if colliding with food
        {
            RefillStamina(maxStamina * 0.5f); // Restore 50% stamina
            Destroy(other.gameObject); // Remove food object
        }
    }
}
