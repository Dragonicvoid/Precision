using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
    Health parent;
    public GameObject peluruPosition;
    public AudioSource hit;

    // Use this for initialization
    void Start()
    {
        parent = GetComponentInParent<Health>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Peluru")
        {
            hit.Play();
            parent.damage(10);
            print(this.gameObject);
        }
    }
}
