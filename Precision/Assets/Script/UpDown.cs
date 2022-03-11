using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 2)
        {
            transform.position = transform.position + transform.up * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && transform.position.y > 0)
        {
            transform.position = transform.position - transform.up * Time.deltaTime;
        }
	}
}
