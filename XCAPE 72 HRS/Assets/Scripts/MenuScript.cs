using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject ChooseLevel;
    public GameObject menu;

    public void StartGame()
    {
        menu.SetActive(false);
        ChooseLevel.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
