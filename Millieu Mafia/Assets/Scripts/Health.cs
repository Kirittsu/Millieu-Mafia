using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    private int currentHealth;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
            this.healthBar.value = currentHealth;
    }

    private void Die()
    {
        // Check if the GameObject is not null before attempting to destroy it
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
        else
        {
            // Log a message if the GameObject is unexpectedly null
            Debug.LogWarning("Attempting to destroy a null GameObject in the Die method.");
        }
    }
}
