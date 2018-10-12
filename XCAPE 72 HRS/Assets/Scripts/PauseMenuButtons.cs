using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuButtons : MonoBehaviour {

    private int index = 0;

    [SerializeField] private GameObject helpMenu;
	[SerializeField] private GameObject pauseMenuHolder;

	public void ResumeGame ()
    {
        PauseSystem.pauseSystem.ResumeGame();
	}

    public void Settings ()
    {
        Debug.Log("Settings");
        helpMenu.SetActive(true);
        pauseMenuHolder.SetActive(false);
    }

    public void HelpBack()
    {
        helpMenu.SetActive(false);
        pauseMenuHolder.SetActive(true);
    }

    public void MainMenu ()
    {
        Debug.Log("Go to Main Menu.");
        SceneManager.LoadScene(index);

    }

    public void QuitGame ()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
