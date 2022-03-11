using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGame : MonoBehaviour {
    Camera endCamera;
    public Camera startCamera;

    // Use this for initialization
    void Start()
    {
        endCamera = GetComponent<Camera>();
        endCamera.enabled = false;
        startCamera = Camera.main;
        startCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
