using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public float attackDelay = 3f; // Time before attack
    public Animator animator;
    private bool hasAttacked = false;
    private PlayerHealth playerHealth; 

    void Start()
    {
        // Get reference to the player's health system
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        // Start the attack sequence
        Invoke("Attack", attackDelay);
    }

    void Attack()
    {
        if (hasAttacked) return;
        hasAttacked = true;

        // Play attack animation
        animator.SetTrigger("Peck");

        // Wait for animation event or delay before applying damage
        Invoke("ApplyDamage", 0.5f); // Adjust timing as needed
    }

    void ApplyDamage()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
        }

        // Destroy bird after attack or make it fly away
        Destroy(gameObject, 1f);
    }
}
