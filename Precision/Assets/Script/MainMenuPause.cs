using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPause : MonoBehaviour {

    private bool isOn = false;
    public GameObject missionDetail1;
    public GameObject missionDetail2;
    public GameObject missionDetail3;
    public GameObject control;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Buka()
    {
        if (!isOn)
        {
            missionDetail1.SetActive(true);
            isOn = true;
        }
        else
        {
            missionDetail1.SetActive(false);
            missionDetail2.SetActive(false);
            missionDetail3.SetActive(false);
            isOn = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
