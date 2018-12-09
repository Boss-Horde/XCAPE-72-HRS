using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {
    bool onTrigger = false;
    GameObject player;
    Light light;
    bool pickedUp = false;
    Vector3 flashlight;

    private void Start()
    {
        light = GetComponentInChildren<Light>();
        light.enabled = false;
        flashlight = transform.position;
    }

    public void Update()
    {
        flashlight.y = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pickedUp)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onTrigger = true;
                player = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onTrigger = false;
        }
    }

    private void OnGUI()
    {
        if (onTrigger)
        {
            GUI.Box(new Rect((Screen.width - 200)/2, (Screen.height-25)/2, 200, 25), "Press 'E' to pick up flashlight.");

            if (Input.GetKeyDown(KeyCode.E))
            {
                onTrigger = false;
                PickUpFlashlight();
            }
        }
    }

    void PickUpFlashlight()
    {
        pickedUp = true;
        //gameObject.GetComponent<SphereCollider>().enabled = false; 

        //gameObject.transform.position = player.transform.position;
        //gameObject.transform.position = flashlight;
        //gameObject.transform.rotation = Quaternion.LookRotation(-player.transform.forward, player.transform.up);
        //gameObject.transform.parent = player.transform;
        //light.enabled = true;

        player.GetComponentInChildren<Light>().enabled = true;

        Destroy(gameObject);
    }
}
