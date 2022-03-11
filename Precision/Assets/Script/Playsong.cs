using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playsong : MonoBehaviour {
    public AudioSource song1;
    public AudioSource song2;
    public AudioSource song3;

    // Use this for initialization
    void Start () {
        int rand = Random.Range(0, 3);
        print(rand);
        if (rand == 0)
        {
            song1.Play();
        }else if (rand == 1)
        {
            song2.Play();
        }
        else
        {
            song3.Play();
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
