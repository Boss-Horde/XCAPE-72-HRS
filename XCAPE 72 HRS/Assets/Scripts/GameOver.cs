using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void LoadGameOver()
    {
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("RevampedRoom1");
    }

    public void Quit()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }
}
