using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BorderWall : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public TMP_Text healthText; // Reference to the UI Text

    private void Start()
    {
        currentHealth = maxHealth;

        // Set the initial health text
        UpdateHealthText();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        // Update the health text whenever the health changes
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destroy the border wall when health reaches zero
        }
    }

    private void UpdateHealthText()
    {
        // Ensure that the healthText reference is not null
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString("F0"); // Display the health as an integer
        }
    }
}
