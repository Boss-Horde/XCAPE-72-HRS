using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenSmallChest : MonoBehaviour
{
    private RigidbodyFirstPersonController firstPersonController;

    public GameObject riddlePanel;
    bool onTrigger = false;
    bool openedChest = false;
    bool solvingRiddle = false;
    InputField input;
    public AudioSource audioSource;
    public AudioClip openChestSound;
    public GameObject key;

    private void Start()
    {
        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
        //riddlePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("TRIGGER ENTERED");

        if (!openedChest)
        {
            if (other.CompareTag("Player"))
            {
                onTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }

    private void OnGUI()
    {
        if (onTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open chest");
            if (Input.GetKeyDown(KeyCode.E))
            {
                solvingRiddle = true;
                onTrigger = false;
            }
        }

        if (solvingRiddle)
        {
            riddlePanel.SetActive(true);
            input = riddlePanel.GetComponentInChildren<InputField>();
            input.ActivateInputField(); 
            input.Select();

            //Cursor.visible = !Cursor.visible;
            firstPersonController.enabled = false;
            GUI.Box(new Rect(50, 400, 200, 25), "Press 'Tab' to give up solving");

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Debug.Log(" exit pressed");
                ExitPanel();
            }
        }
    }


    public void CheckInputString(string guess)
    {
        if (input != null)
        {
            string answer = guess.ToLower();
            if (answer.Equals("men"))
            {
                firstPersonController.enabled = true;
                openedChest = true;
            
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                solvingRiddle = false;
                riddlePanel.SetActive(false);
                PlayChestAnimation();
            }
            else
            {
                input.text = "";
                input.ActivateInputField();
                input.Select();
            }
        }
        else
            return;
    }

    public void CheckInputSecond(string guess2)
    {
        if (input != null)
        {
            string answer = guess2.ToLower();
            if (answer.Equals("n"))
            {
                firstPersonController.enabled = true;
                openedChest = true;
            
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                solvingRiddle = false;
                riddlePanel.SetActive(false);
                PlayChestAnimation();
            }
            else
            {
                input.text = "";
                input.ActivateInputField();
                input.Select();
            }
        }
    }

    void PlayChestAnimation()
    {
        key.SetActive(true);
        ExitPanel();
        Destroy(gameObject.GetComponent<BoxCollider>());
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Unlock");
        StartCoroutine(DelayOpenChestSound());
    }

    void ExitPanel()
    {
        firstPersonController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        solvingRiddle = false;

        riddlePanel.SetActive(false);
    }

    IEnumerator DelayOpenChestSound()
    {
        yield return new WaitForSeconds(.4f);
        audioSource.PlayOneShot(openChestSound, .7f);
    }
}
