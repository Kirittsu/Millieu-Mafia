using UnityEngine;

public class BorderEnemySystem : MonoBehaviour
{
    public Transform borderDestination;
    public float speed = 5f;
    public float hoverHeight = 2f;
    public float damageToWall = 10f;
    private bool isDead = false;


    Rigidbody rb;
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (!isDead)
        {
            MoveToBorder();
            Hover();
        }
    }

    private void MoveToBorder()
    {
        if (borderDestination == null)
        {
            Destroy(gameObject); // Destroy the enemy if the destination is null
            return;
        }

        Vector3 directionToBorder = (borderDestination.position - transform.position).normalized;
        transform.Translate(directionToBorder * speed * Time.deltaTime);
    }

    private void Hover()
    {
        // Cast a ray downward to detect the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Set the enemy's position to hover above the ground
            transform.position = new Vector3(transform.position.x, hit.point.y + hoverHeight, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BorderWall"))
        {
            TakeDamage();
            Die();
        }
        else if (!isDead && other.CompareTag("Bullet"))
        {
            // Take damage from the bullet
            Destroy(other.gameObject); // Destroy the bullet
            TakeDamage();
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

    private void TakeDamage()
    {
        // Check if the enemy has a BorderWall script attached
        if (borderDestination == null) return;

        BorderWall borderWall = borderDestination.GetComponent<BorderWall>();

        // Cause damage to the border wall
        if (borderWall != null)
        {
            borderWall.TakeDamage(damageToWall);
        }
        
    }

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

    private void Die()
    {
        // Perform any actions when the enemy dies
        // For example, play a death animation or destroy the enemy GameObject
        isDead = true;
        gameObject.SetActive(false); // Make the enemy invisible
    }
}
