using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

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

            PauseGame(0);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeGame(1);
        }
    }

    public void PauseGame (int time)
    {
        isPaused = true;
        GameManager.gameManager.UpdateMotion(time);

        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuHolder.SetActive(true);
    }
     
    public void ResumeGame(int time)
    {
        isPaused = false;
        firstPersonController.enabled = true;
        GameManager.gameManager.UpdateMotion(time);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuHolder.SetActive(false);
        helpMenu.SetActive(false);
    }
    
    
}
