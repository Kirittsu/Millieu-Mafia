using UnityEngine;

/// <summary>
/// Removes the attached game object when a specified victory condition is met.
/// </summary>
public class ObjectRemover : MonoBehaviour
{
	public SkyboxController skyboxController; // Reference to the SkyboxController object. Assign in the Inspector.

	/// <summary>
	/// Called every frame to check the victory condition and remove the game object.
	/// </summary>
	void Update()
	{
		// Check if the SkyboxController reference is not null and the victory condition is met
		if (skyboxController != null && skyboxController.victory)
		{
			// Destroy the attached game object
			Destroy(gameObject);
		}
	}
}
