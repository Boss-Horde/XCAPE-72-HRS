using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseSystem : MonoBehaviour
{
    public static PauseSystem pauseSystem;

    private bool isPaused = false;
    private CharacterController charController;
    private RigidbodyFirstPersonController firstPersonController;


    [SerializeField] private GameObject pauseMenuHolder;
    [SerializeField] private GameObject helpMenu;

	void Start ()
    {
        pauseSystem = this;
        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {

            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame ()
    {
        isPaused = true;

        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuHolder.SetActive(true);
    }
     
    public void ResumeGame()
    {
        isPaused = false;
        firstPersonController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuHolder.SetActive(false);
        helpMenu.SetActive(false);
    }
    
    
}
