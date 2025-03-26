using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxLives = 3;
    private int currentLives;

    [Header("Shell Protection")]
    public bool hasShell = false;

    [Header("UI Elements")]
    public Text livesText;

    [Header("Audio")]
    public AudioClip damageSound;      // Assign in Inspector
    public AudioClip shellBreakSound;  // Assign in Inspector
    private AudioSource audioSource;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
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

            // Play damage sound
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
            }

            // Flash red
            if (spriteRenderer != null)
            {
                StopAllCoroutines();
                StartCoroutine(FlashRed());
            }

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

        // Play shell break sound
        if (shellBreakSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shellBreakSound);
        }

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

    private IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
