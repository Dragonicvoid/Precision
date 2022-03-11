using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Shoot.shoot = 0;
        Health.die = 0;
        Pause.isDefault = true;
        Health.gameover = false;
        Mulai.hold = 0;
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
