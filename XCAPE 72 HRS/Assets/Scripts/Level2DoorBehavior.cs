using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2DoorBehavior : MonoBehaviour
{

    public Animator animator;

    private bool playerNextToDoor;

    public AudioClip openDoorSound;
    public AudioClip doorLockedSound;
    public float Volume;
    AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        playerNextToDoor = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerNextToDoor = false;
    }

    // Use this for initialization
    void Start()
    {
        playerNextToDoor = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNextToDoor && Input.GetKeyDown(KeyCode.E))
        {          // If player does have key, need add condition
                   //if (Inventory.inventory.items.GetValue(3).Equals(true)){
            if (Inventory.inventory.amountOfItems.Equals(2))
            {
                audioSource.PlayOneShot(openDoorSound, Volume);
                StartCoroutine(LoadNextLevel());
            }
            else
            {
                audioSource.PlayOneShot(doorLockedSound, Volume);
            }
        }
        // FOR FUTURE USE: FOR LEVELS AFTER LEVEL ONE, TWEEK CONDITIONS TO INCLUDE DIFFERENT ITEMS OR CONDITIONS TO TRIGGER ANIMATION AND LEVEL LOADING
    }

    IEnumerator LoadNextLevel()
    {
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(3);
    }
}
