using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    private bool hold = true;
    private float timer = 0f;
    public static int shoot = 0;
    public Text text;
    public Text text2;
    private float wind;
    private float distance;
    private float distanceOld;
    private Camera m;
    private int layer;
    public Transform bulletPoint;
    public AudioSource audioTembak;
    public AudioSource audioReload;

    // Use this for initialization
    void Start () {
        wind = Bullet1.wind;
        text.text = "Wind : " + wind;
        distance = 0;
        distanceOld = 0;
        m = Camera.main;
        layer = LayerMask.GetMask("Tubuh");
        text2.text = "Distance : " + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bullet1.wind != wind)
        {
            wind = Bullet1.wind;
            text.text = "Wind : " + wind;
        }

        if (distanceOld != distance)
        {
            distanceOld = distance;
            text2.text = "Distance : " + (int)distance;
        }

        if (timer >= 4)
        {
            audioReload.Stop();
            if (Input.GetMouseButtonDown(0) && Pause.isDefault == true && Health.die < 1)
            {
                audioTembak.Play();
                timer = 0;
                shoot++;
                bullet.SetActive(true);
                hold = true;
            }
        }

        if (timer < 4)
        {
            if (timer > 0.5f && hold)
            {
                hold = false;
                audioReload.Play();
            }
            timer += Time.deltaTime;
        }

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 100);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, layer))
        {
            distance = Vector3.Distance(transform.position, hit.transform.position);
        }

    }
}
