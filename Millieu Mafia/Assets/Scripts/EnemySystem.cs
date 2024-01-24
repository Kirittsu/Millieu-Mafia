using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySystem : MonoBehaviour
{
    bool lookat = false;
    public GameObject player;
    Rigidbody rb;
    public float speed = 10;
    public float multiplier = 10;
    public float speed_limit = 2;


    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;





    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
    }

   
    void Update()
    {
        
        if (PlayerDetection.found)
        {
            lookat = true;
        }
        if (lookat)
        {
            transform.LookAt(player.transform);
            Vector3 vel = rb.velocity;
            if (!PlayerDetection.found && vel.x > speed_limit * -1 && vel.x < speed_limit && vel.z > speed_limit*-1 && vel.z < speed_limit)
            {
                rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);
                
            }
            
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletHit();
            Destroy(collision.gameObject);
        }
    }

    // Method to handle actions when a bullet hits the enemy
    void BulletHit()
    {
        float damage = 20f; // You can adjust the damage amount as needed

        _currentHealth -= damage;

        // Ensure health doesn't go below zero
        _currentHealth = Mathf.Max(_currentHealth, 0);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle actions when the enemy dies
    void Die()
    {
        // Perform any actions when the enemy dies
        // For example, play a death animation or destroy the enemy GameObject
        Destroy(gameObject);
    }

}
