using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxLives = 3;
    private int currentLives;

    [Header("Shell Protection")]
    public bool hasShell = false; // Whether the player has a shell

    [Header("UI Elements")]
    public Text livesText; // UI to show lives

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();
    }

    public void TakeDamage()
    {
        if (hasShell)
        {
            BreakShell();
        }
        else
        {
            currentLives--;
            UpdateLivesUI();

            if (currentLives <= 0)
            {
                Die();
            }
        }
    }

    public void CollectShell()
    {
        hasShell = true;
    }

    private void BreakShell()
    {
        hasShell = false;
        Debug.Log("The shell broke but saved the player!");
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add respawn or game over logic here
    }
}
