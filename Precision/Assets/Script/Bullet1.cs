using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet1 : MonoBehaviour {

    private Rigidbody rg;
    public Transform bulletPoint;
    public GameObject bulletTrail;
    private Vector3 windy;
    private float timer = 4;
    public static float wind;
    private bool hold = true;
    private float timer2 = 0;
    private float hold2 = 0;
    private bool hit = false;

	// Use this for initialization
	void Start () {
        wind = Random.Range(-20, 20);
        transform.position = bulletPoint.position;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        hold2 = 0;
        hit = false;
        gameObject.tag = "Peluru";
        rg = GetComponent<Rigidbody>();
        transform.position = bulletPoint.position;
        transform.rotation = bulletPoint.rotation;
        transform.Rotate(90, 0, 0);
        rg.isKinematic = false;
        rg.AddForce(transform.up * 25);
        rg.AddForce(transform.forward * 1f);
    }

    // Update is called once per frame
    void Update () {
        timer -= Time.deltaTime;
        timer2 += Time.deltaTime;

        if (timer2 > 0.3f)
        {
            Instantiate(bulletTrail, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            timer2 = 0;
        }

        if (timer < 3.5 && hold)
        {
            rg.AddForce(transform.right * wind * 0.1f);
            hold = false;
        }

        if (timer <= 0)
        {
            hold = true;
            timer = 4;
            transform.position = bulletPoint.position;
            rg.isKinematic = true;
            gameObject.SetActive(false);
        }

        if (hit)
        {
            hold2 += Time.deltaTime;
        }

        if (hold2 > 0.05f)
        {
            gameObject.tag = "PeluruMati";
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        hit = true;
    }
}
