using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject GamePanel;
    static public bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) Pause();
        if (Input.GetKeyDown(KeyCode.Escape)) Continue();
        if (isPaused == true)
        {
            if (Input.GetKeyDown(KeyCode.M)) GoToMainMenu();
        }
    }
    public void Pause()
    {
        PausePanel.SetActive(true);
        GamePanel.SetActive(false);
        Time.timeScale = 0;
        isPaused = true;
	}
	public void Continue()
	{
		PausePanel.SetActive(false);
        GamePanel.SetActive(true);
		Time.timeScale = 1;
        isPaused = false;
	}
	public void GoToMainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
}
