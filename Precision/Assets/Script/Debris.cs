using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {
    public GameObject smoke;
    public AudioSource audio2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            gameObject.SetActive(true);
            audio2.Play();
        }
    }
}
