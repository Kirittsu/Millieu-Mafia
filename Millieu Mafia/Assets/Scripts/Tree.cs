using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of a tree object, including health points and damage.
/// </summary>
public class Tree : MonoBehaviour
{
	private int hp = 200; // Health points of the tree.
	public bool isAlive = true; // Flag indicating if the tree is alive.

	// Start is called before the first frame update
	void Start()
	{
		// Initialization code if needed
	}

	// Update is called once per frame
	void Update()
	{
		// Check if the tree's health points have reached zero and destroy the tree if necessary
		if (hp <= 0) Destroy(gameObject);
	}

	/// <summary>
	/// Inflicts damage on the tree and updates its alive status.
	/// </summary>
	/// <param name="damage">Amount of damage to inflict.</param>
	public void TakeDamage(int damage)
	{
		hp -= damage; // Reduce the health points of the tree by the specified amount.
		isAlive = false; // Set the alive flag to false.
	}
}
