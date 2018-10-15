using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypad : MonoBehaviour
{

    public string currentPassword = "3257";
    public string input;
    public string tempInput;
    public bool onTrigger;
    public bool safeOpened;
    public bool keypadScreen;

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;

    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    private void Update()
    {
        if (input == currentPassword)
        {
            safeOpened = true;
        }
        if (safeOpened)
        {
            SafeAnimation();
        }
    }

    private void OnGUI()
    {
        Cursor.visible = true;
        if (onTrigger)
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Press 'E to open keypad");

            if (Input.GetKeyDown(KeyCode.E))
            {
                keypadScreen = true;
                onTrigger = false;
            }

        }

        if (keypadScreen)
        {

            GUI.Box(new Rect(0, 0, 320, 400), "");
            GUI.Box(new Rect(5, 5, 310, 25), input);

            if (input.Length > 4)
            {
                input = "";
            }
            if (GUI.Button(new Rect(5, 25, 50, 50), "1"))
            {
                input = input + "1";
            }

            if (GUI.Button(new Rect(110, 25, 50, 50), "2"))
            {
                input = input + "2";
            }

            if (GUI.Button(new Rect(215, 25, 50, 50), "3"))
            {
                input = input + "3";
            }

            if (GUI.Button(new Rect(5, 140, 50, 50), "4"))
            {
                input = input + "4";
            }

            if (GUI.Button(new Rect(110, 140, 50, 50), "5"))
            {
                input = input + "5";
            }

            if (GUI.Button(new Rect(215, 140, 50, 50), "6"))
            {
                input = input + "6";
            }

            if (GUI.Button(new Rect(5, 245, 50, 50), "7"))
            {
                input = input + "7";
            }

            if (GUI.Button(new Rect(110, 245, 50, 50), "8"))
            {
                input = input + "8";
            }

            if (GUI.Button(new Rect(215, 245, 50, 50), "9"))
            {
                input = input + "9";
            }

            if (GUI.Button(new Rect(110, 350, 50, 50), "0"))
            {
                input = input + "0";
            }


        }
    }

    void SafeAnimation()
    {
        Animator anim = GetComponentInParent<Animator>();
        anim.SetBool("open", true);
    }
}
