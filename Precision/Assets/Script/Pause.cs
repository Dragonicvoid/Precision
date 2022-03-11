using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Pause : MonoBehaviour {

    private FirstPersonController fpc;
    private CharacterController cc;
    public GameObject pause;
    public GameObject hud;
    public static bool isDefault = true;

	// Use this for initialization
	void Start () {
        fpc = GetComponent<FirstPersonController>();
        cc = GetComponent<CharacterController>();
        isDefault = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !Health.gameover)
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
                hud.SetActive(true);
            }
            fpc.enabled = !fpc.enabled;
            cc.enabled = !cc.enabled;
            print(isDefault);
        }
	}
}
