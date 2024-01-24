using UnityEngine;

public class DamagaPlayer : MonoBehaviour
{
    // UIManager
    private UIManager _uiManager;

    private int maxHealth = 100;
    private int currentHealth;

    public int healingAmount = 20;
    public float healingDuration = 5f;

    private bool isHealing = false;

    // Audio
    public AudioClip healSound;
    public AudioClip damageSound;  // Nieuwe variabele voor het geluid van schade
    private AudioSource audioSource;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        currentHealth = maxHealth;
        _uiManager.updateHealth(currentHealth, maxHealth);

        // Search for the AudioSource component in the current GameObject or its children
        audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource is not found, create one and attach it to the current GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        _uiManager.updateHealth(currentHealth, maxHealth);

        // Play the damage sound
        if (audioSource != null && damageSound != null)
        {
            audioSource.clip = damageSound;
            audioSource.Play();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.F) && !isHealing)
            {
                StartHealing();
            }

            if (isHealing)
            {
                healingDuration -= Time.deltaTime;

                if (healingDuration <= 0f)
                {
                    StopHealing();
                }
            }
        }
    }

    private void StopHealing()
    {
        isHealing = false;
        healingDuration = 5f;
        CancelInvoke("HealPlayer");

        // Stop the healing sound if it's still playing
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Voeg hier eventuele visuele effecten toe voor het stoppen van de genezing
    }

    private void StartHealing()
    {
        isHealing = true;
        InvokeRepeating("HealPlayer", 0f, 1f); // Herhaal elke seconde

        // Play the healing sound
        if (audioSource != null && healSound != null)
        {
            audioSource.clip = healSound;
            audioSource.Play();
        }

        // Voeg hier eventuele visuele effecten toe voor de genezing
    }

    private void HealPlayer()
    {
        if (currentHealth < maxHealth)
        {
            float progress = 1f - (healingDuration / 5f); // Bereken de voortgang van 0 naar 1 over 5 seconden
            float newHealth = Mathf.Lerp(currentHealth, currentHealth + healingAmount, progress);

            // Update de gezondheid
            currentHealth = Mathf.Clamp((int)newHealth, 0, maxHealth);
            _uiManager.updateHealth(currentHealth, maxHealth);
        }
        else
        {
            StopHealing(); // Stop de genezing als de gezondheid het maximum heeft bereikt
        }
    }

    private void Die()
    {
        // Implement any logic for object death (e.g., play death animation, spawn particles, etc.)
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }
}
