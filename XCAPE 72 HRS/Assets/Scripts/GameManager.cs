using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class GameManager : MonoBehaviour
{

    public static GameManager gameManager;
    [HideInInspector] public bool inGameFunction;

    private RigidbodyFirstPersonController firstPersonController;
    private GameObject firstPersonCharacter;

    void Awake()
    {
        gameManager = this;
    }

    void Start()
    {
        SetReferences();

        UpdateMotion(1);
        LockCursor();
    }

    private void SetReferences()
    {

        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        firstPersonCharacter = GameObject.Find("RigidBodyFPSController").gameObject;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void EnableControls()
    {
        firstPersonController.enabled = true;
    }

    public void DisableControls()
    {
        firstPersonController.enabled = false;
    }

    public void UpdateMotion(int time)
    {
        Time.timeScale = time;
    }
}
