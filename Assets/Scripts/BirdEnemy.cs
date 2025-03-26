using UnityEngine;
using System.Collections;

public class BirdEnemy : MonoBehaviour
{
    public float warningDelay = 1f;
    public float damageDelay = 1.5f;
    public float disappearDelay = 3f;
    public float respawnMin = 5f;
    public float respawnMax = 10f;
    public AudioClip warningSound;
    public Sprite warningSprite;
    public Sprite attackSprite;

    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private PlayerHealth playerHealth;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        // Hide sprite but keep object active
        Hide();

        // Start attack loop
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(respawnMin, respawnMax));
            PositionInCameraCorner();

            // Warning stage
            Show(warningSprite);
            if (warningSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(warningSound);
            }

            yield return new WaitForSeconds(warningDelay);

            // Attack stage
            Show(attackSprite);

            yield return new WaitForSeconds(damageDelay);

            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }

            yield return new WaitForSeconds(disappearDelay);
            Hide();
        }
    }

    void Hide()
    {
        if (spriteRenderer != null)
            spriteRenderer.enabled = false;
    }

    void Show(Sprite sprite)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = sprite;
            spriteRenderer.enabled = true;
        }
    }

    void PositionInCameraCorner()
    {
        Camera cam = Camera.main;
        if (cam != null)
        {
            Vector3 cornerPos = cam.ViewportToWorldPoint(new Vector3(.9f, .2f, cam.nearClipPlane + 5f));
            cornerPos.z = 0;
            transform.position = cornerPos;
        }
    }
}
