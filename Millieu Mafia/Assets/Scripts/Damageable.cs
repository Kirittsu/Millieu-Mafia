using UnityEngine;
using UnityEngine.UI; 

public class Damageable : MonoBehaviour
{
    // UIManager
    private UIManager _uiManager;

    // Slidebar Manager
    public Slider healthBar;

    private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        _uiManager = GameObject.Find("EnemyCanvas").GetComponent<UIManager>();
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        _uiManager.updateHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        healthBar.value = this.currentHealth;
    }

    private void Die()
    {
        // Implement any logic for object death (e.g., play death animation, spawn particles, etc.)
        Debug.Log(gameObject.name + " died");
        Destroy(gameObject);
    }
}
