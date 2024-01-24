using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement any logic for object death (e.g., play death animation, spawn particles, etc.)
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
            healthBar.value = currentHealth;
    }
}
