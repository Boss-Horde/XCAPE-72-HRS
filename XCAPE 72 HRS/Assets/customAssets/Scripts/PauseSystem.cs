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
    [SerializeField] private GameObject settingsHolder;

	void Start ()
    {
        pauseSystem = this;
        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
    }
	
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            //if (GameManager.gameManager.inGameFunction) return;


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
        //GameManager.gameManager.inGameFunction = true;

        //GameManager.gameManager.UnlockCursor();
        //GameManager.gameManager.EnableBlurEffect();
        //GameManager.gameManager.UpdateMotion(0);
        //GameManager.gameManager.DisableControls();

        firstPersonController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        pauseMenuHolder.SetActive(true);
    }
     
    public void ResumeGame()
    {
        isPaused = false;
        firstPersonController.enabled = true;

        //GameManager.gameManager.inGameFunction = false;

        //GameManager.gameManager.LockCursor();
        //GameManager.gameManager.DisableBlurEffect();
        //GameManager.gameManager.UpdateMotion(1);
        //GameManager.gameManager.EnableControls();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuHolder.SetActive(false);
        //settingsHolder.SetActive(false);
    }
    
    
}
