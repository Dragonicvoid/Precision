using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause2 : MonoBehaviour {

    public GameObject pause;
    public GameObject hud;
    public bool isDefault = true;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isDefault)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isDefault = false;
                pause.SetActive(true);
                hud.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                isDefault = true;
                pause.SetActive(false);
            }
        }
    }
}
