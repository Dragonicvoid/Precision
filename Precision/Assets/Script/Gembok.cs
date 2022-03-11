using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gembok : MonoBehaviour {
    public AudioSource hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Peluru")
        {
            hit.Play();
            Destroy(this.gameObject);
        }
    }
}
