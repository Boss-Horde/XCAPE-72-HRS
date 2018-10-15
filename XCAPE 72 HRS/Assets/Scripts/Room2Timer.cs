using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Room2Timer : MonoBehaviour
{

    public Text timerText;
    private float time = 600;
    //public GameOver dead;

    void Start()
    {
        StartCoundownTimer();
    }

    void StartCoundownTimer()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: 10:00:000";
            InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
        }
    }

    void UpdateTimer()
    {
        Debug.Log(time);

        if (timerText != null)
        {
            if (time < 0.01f)
            {
                Debug.Log("If statement entered");
                //CancelInvoke();
                //dead.LoadGameOver();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("GameOver");

            }
            time -= Time.deltaTime;
            string minutes = Mathf.Floor(time / 60).ToString("00");
            string seconds = (time % 60).ToString("00");
            //string fraction = ((time * 100) % 100).ToString("000");
            //timerText.text = "Time Left: " + minutes + ":" + seconds + ":" + fraction;
            timerText.text = "Time Left: " + minutes + ":" + seconds;

        }
    }
}
