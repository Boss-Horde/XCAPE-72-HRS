using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenSmallChest : MonoBehaviour {

    public GameObject riddlePanel;
    bool onTrigger = false;
    bool openedChest = false;
    InputField input;

    private void Start()
    {
        riddlePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!openedChest)
        {

            Cursor.visible = !Cursor.visible;
            if (other.CompareTag("Player"))
            {
                onTrigger = true;
                riddlePanel.SetActive(true);
                input = riddlePanel.GetComponentInChildren<InputField>();
                input.ActivateInputField();
                input.Select();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            riddlePanel.SetActive(false);
        }
    }

    public void CheckInputString()
    {
        if (input != null)
        {
            string answer = input.text.ToLower();
            if (answer.Equals("men"))
            {
                openedChest = true;
                PlayChestAnimation();
                riddlePanel.SetActive(false);
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

    public void CheckInputSecond()
    {
        if (input != null)
        {
            string answer = input.text.ToLower();
            if (answer.Equals("n"))
            {
                openedChest = true;
                PlayChestAnimation();
                riddlePanel.SetActive(false);
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
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Unlock");
    }
}
