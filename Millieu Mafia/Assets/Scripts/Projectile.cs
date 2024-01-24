using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            DamageEnemy damageEnemy = other.gameObject.GetComponent<DamageEnemy>();

            if (damageEnemy != null)
            {
                // Roep de TakeDamage-methode aan op het object
                damageEnemy.TakeDamage(damage);
            }
        }
    }
}
