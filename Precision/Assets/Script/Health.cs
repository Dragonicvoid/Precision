using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    int health = 10;
    public GameObject peluruPosition;
    Rigidbody body;
    bool hold = true;
    public static int die = 0;
    public bool isDead = false;
    public GameObject uiLose;
    public GameObject uiWin;
    public GameObject control;
    public GameObject gui;
    private float timer = 3;
    public Camera startCamera;
    public Camera endCamera;
    public static bool gameover = false;

	// Use this for initialization
	void Start () {
        die = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0 && hold)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                body = transform.GetChild(i).GetComponent<Rigidbody>();
                body.isKinematic = false;
                body.useGravity = true;
                body.AddForce((transform.position - peluruPosition.transform.position) * 50);
            }
            die++;
            isDead = true;
            Destroy(gameObject, 5f);
            hold = false;
        }

        if (isDead)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                startCamera.enabled = false;
                endCamera.enabled = true;
                if (gameObject.tag == "Target")
                {
                    gameover = true;
                    uiWin.SetActive(true);
                    uiLose.SetActive(false);
                    control.SetActive(false);
                    gui.SetActive(false);
                }
                else if (gameObject.tag != "Target")
                {
                    gameover = true;
                    uiLose.SetActive(true);
                    uiWin.SetActive(false);
                    control.SetActive(false);
                    gui.SetActive(false);
                }
            }
        }
	}

    public void damage(int a)
    {
        health -= a;
    }

}
