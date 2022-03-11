using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerbang : MonoBehaviour {

    public GameObject gembok;
    Rigidbody rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gembok == null)
        {
            rg.useGravity = true;
            rg.isKinematic = false;
            Destroy(this, 3f);
        }
	}
}
