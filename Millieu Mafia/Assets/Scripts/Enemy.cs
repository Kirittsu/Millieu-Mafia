using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// Manages the behavior of enemy entities in the game.
/// </summary>
public class Enemy : MonoBehaviour
{
	private int hp = 20; // Health points of the enemy.
	[SerializeField] private Transform spawnPoint; // The spawn point of the enemy.
	public List<Transform> destinations; // List of possible movement destinations for the enemy.
	private float speed = 120f; // Movement speed of the enemy.
	private Rigidbody rb; // Rigidbody component of the enemy.
	private System.Random random = new System.Random(); // Random number generator for selecting movement destinations.
	private Vector3 destination; // The current movement destination of the enemy.
	private int treeCount = 10;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		destination = destinations[random.Next(0, 10)].position; // Initialize the initial movement destination randomly.
	}

	// Update is called once per frame
	void Update()
	{
		if (hp <= 0) Destroy(gameObject); // Destroy the enemy if its health points reach zero.

		Vector3 newPos = Vector3.MoveTowards(rb.position, destination, speed * Time.deltaTime);
		rb.MovePosition(newPos); // Move the enemy towards its current destination.
	}

	/// <summary>
	/// Inflicts damage on the enemy.
	/// </summary>
	/// <param name="damage">Amount of damage to inflict.</param>
	public void TakeDamage(int damage)
	{
		hp -= damage; // Reduce the health points of the enemy by the specified amount.
	}

	/// <summary>
	/// Called when the enemy collides with another collider.
	/// </summary>
	/// <param name="other">The collider object with which the enemy collides.</param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Tree>() != null)
		{
			// Check if the collider object is tagged as "Tree" or belongs to a parent object tagged as "Tree"
			if (other.gameObject.CompareTag("Tree") || other.transform.parent.gameObject.CompareTag("Tree"))
			{
				// Inflict damage on the tree and log the event
				other.GetComponent<Tree>().TakeDamage(200);
				Debug.Log("Tree Hit");
			}
		}
		if (other.GetComponent<Tree>() == null)
		{
			treeCount--;
		}
	}
}
