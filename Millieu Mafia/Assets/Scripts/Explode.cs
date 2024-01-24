using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float explosionForce = 1f;
    public float explosionRadius = 5f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > explosionForce)
        {
            Explosion();
        }
    }

    void Explosion()
    {
        // Voer hier de acties uit die je wilt ondernemen wanneer het object ontploft
        // Bijvoorbeeld, vernietig dit object
        Destroy(gameObject);

        // Of voer een explosie-effect uit
        // Instantiate(explosionEffect, transform.position, transform.rotation);

        // Of pas kracht toe op nabijgelegen objecten
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    }
}
