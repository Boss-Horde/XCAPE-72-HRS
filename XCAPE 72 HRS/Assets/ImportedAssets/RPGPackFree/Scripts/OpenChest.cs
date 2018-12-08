using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {

    public GameObject riddlePanel;
    bool onTrigger = false;
    bool openedChest = false;
    string CHAIR_ANSWER = "chair";
    int FRIDGE_ANSWER = 110;
    InputField input;

    private void Start()
    {
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
            
            Cursor.visible = !Cursor.visible;
            if (other.CompareTag("Player"))
            {
                onTrigger = true;
                riddlePanel.SetActive(true);
                input = riddlePanel.GetComponentInChildren<InputField>();
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
        Animator anim = gameObject.GetComponent<Animator>();
        anim.SetTrigger("Unlock");
    }

}
