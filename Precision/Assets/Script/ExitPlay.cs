using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPlay : MonoBehaviour {

    public GameObject levelSelect;
    private bool isDefault = true;
    public Animator anim;
    private float hold = 0f;
    private bool hold1 = false;
    private bool hold2 = false;
    private float timer1 = 0f;
    private float timer2 = 0f;
    public Animator anim2;
    public GameObject ui;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefault)
        {
            hold += Time.deltaTime;
        }

        if (hold1)
        {
            timer1 += Time.deltaTime;
        }else if (hold2)
        {
            timer2 += Time.deltaTime;
        }

        if (timer1 > 2.5f)
        {
            SceneManager.LoadScene(1);
        }else if (timer2 > 2.5f)
        {
            SceneManager.LoadScene(2);
        }
	}

    public void PlayButton()
    {
        if (isDefault)
        {
            anim.SetTrigger("Trigger");
            isDefault = false;
            levelSelect.SetActive(true);
        }
        else if(!isDefault && hold > 0.3f)
        {
            hold = 0;
            isDefault = true;
            levelSelect.SetActive(false);
        }else if (!isDefault)
        {
            anim.SetTrigger("Trigger2");
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void Level1Button()
    {
        hold1 = true;
        ui.SetActive(true);
        anim2.SetTrigger("Trigger");
    }

    public void Level2Button()
    {
        hold2 = true;
        ui.SetActive(true);
        anim2.SetTrigger("Trigger");
    }
}
