using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the behavior of the skybox in response to game events, such as victory.
/// </summary>
public class SkyboxController : MonoBehaviour
{
	public Material clearSkyMaterial; // Material for the clear sky.
	public Material dirtySkyMaterial; // Material for the dirty sky.
	public bool victory = false; // Flag indicating if the game has been won.

	/// <summary>
	/// Called at the start of the game. Initializes the skybox with a dirty sky and schedules victory after a specified delay.
	/// </summary>
	void Start()
	{
		RenderSettings.skybox = dirtySkyMaterial;
		Invoke("WinGame", 121f); // Invoke the WinGame method after a delay of 181 seconds.
	}
	void Update()
	{
		if (victory == true) Invoke("LoadScene", 10f);
	}
	/// <summary>
	/// Call this method when the game is won. Changes the skybox to the clear sky material and sets the victory flag.
	/// </summary>
	public void WinGame()
	{
		// Change the skybox to the "ClearSky" material
		RenderSettings.skybox = clearSkyMaterial;
		victory = true; // Set the victory flag to true
	}
	public void LoadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
