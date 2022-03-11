using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool hold = true;
    public GameObject crosshair;

	// Use this for initialization
	void Start () {
        Camera.main.fieldOfView = 60;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if (hold) {
                Camera.main.fieldOfView = 30;
                hold = false;
                crosshair.transform.localScale *= 5;
            }
            else
            {
                Camera.main.fieldOfView = 60;
                hold = true;
                crosshair.transform.localScale /= 5;
            }
        }
	}
}
