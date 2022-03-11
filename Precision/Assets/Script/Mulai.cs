using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mulai : MonoBehaviour {
    public Animator anim;
    public GameObject obj;
    public static float hold = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        hold += Time.deltaTime;
        if (hold > 2)
        {
            anim.SetTrigger("Trigger");
            Destroy(obj, 2.5f);
            Destroy(this.gameObject);
        }
	}
}
