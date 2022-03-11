using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

    public GameObject rope;
    Rigidbody rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rope == null)
        {
            rg.isKinematic = false;
        }
	}
}
