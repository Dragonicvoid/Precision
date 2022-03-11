using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour {

    private float floatSpeed = 5;
    private int naikTurun = -1;
    private float timer = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * naikTurun * 0.2f, 0.5f * Time.deltaTime);


        if (timer <= 0)
        {
            naikTurun *= -1;
            timer = 1f;
        }
	}
}
