using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenChest : MonoBehaviour {

    private RigidbodyFirstPersonController firstPersonController;
    public GameObject riddlePanel;
    bool onTrigger = false;
    bool openedChest = false;
    bool solvingRiddle = false;
    string CHAIR_ANSWER = "chair";
    int FRIDGE_ANSWER = 110;
    InputField input;
    public AudioSource audioSource;
    public AudioClip openChestSound;
    public GameObject key;

    private void Start()
    {
        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
        riddlePanel.SetActive(false);
    }

    /*
    [Range(0.0f, 1.0f)]
    public float factor;

    Quaternion closedAngle;
    Quaternion openedAngle;

    public bool closing;
    public bool opening;

    public float speed = 0.5f;

    int newAngle = 127;

    // Use this for initialization
    void Start () {
        openedAngle = transform.rotation;
        closedAngle = Quaternion.Euler(transform.eulerAngles + Vector3.right * newAngle);
    }
	
	// Update is called once per frame
	void Update () {

        if (closing)
        {
            factor += speed * Time.deltaTime;

            if (factor > 1.0f)
            {
                factor = 1.0f;
            }
        }
        if (opening)
        {
            factor -= speed * Time.deltaTime;

            if (factor < 0.0f)
            {
                factor = 0.0f;
            }
        }

        transform.rotation = Quaternion.Lerp(openedAngle, closedAngle, factor);
	}

    //You probably want to call this somewhere
    void Close()
    {
        closing = true;
        opening = false;
    }

    void Open()
    {
        opening = true;
        closing = false;
    }
    */
    private void OnTriggerEnter(Collider other)
    {
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
        if (other.CompareTag("Player"))
        {

            riddlePanel.SetActive(false);
        }
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

    public void CheckInputString()
    {
        if (input != null)
        {
            string answer = input.text.ToLower();
            if (answer.Equals(CHAIR_ANSWER))
            {
                openedChest = true;
                PlayChestAnimation();
                riddlePanel.SetActive(false);
            } else
            {
                input.text = "";
                input.ActivateInputField();
                input.Select();
            }
        }
        else
            return;
    }

    public void CheckInputNumber()
    {
        int compareNum = int.Parse(input.text);

        if (compareNum == FRIDGE_ANSWER)
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

    void PlayChestAnimation()
    {
        key.SetActive(true);
        Destroy(gameObject.GetComponent<BoxCollider>());
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Unlock");
        StartCoroutine(DelayOpenChestSound());
        ExitPanel();
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
