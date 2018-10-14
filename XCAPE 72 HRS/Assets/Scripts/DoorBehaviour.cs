using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorBehaviour : MonoBehaviour {

    public Animator animator; 

    private bool playerNextToDoor;

    public AudioClip openDoorSound;
    public AudioClip doorLockedSound;
    public float Volume;
    AudioSource audioSource;

    private void OnTriggerEnter(Collider other) {
        playerNextToDoor = true;
    }

    private void OnTriggerExit(Collider other) {
        playerNextToDoor = false;
    }

    // Use this for initialization
    void Start () {
        playerNextToDoor = false;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerNextToDoor && Input.GetKeyDown(KeyCode.E)) {          // If player does have key, need add condition
            audioSource.PlayOneShot(openDoorSound, Volume);
            StartCoroutine(LoadNextLevel());
        }
        /*
        else if (playerNextToDoor && Input.GetKeyDown(KeyCode.E)) {     // If player doesn't have key, need add condition
           audioSource.PlayOneShot(doorLockedSound, Volume);
        }   
        */
    }

    IEnumerator LoadNextLevel()
    {
        //animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
