using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour {

    public GameObject OptionUI;

    bool paused = false;
	
    void Start()
    {
        OptionUI.SetActive(false);
    }

	void Update ()
    {
        if (paused)
        {
            OptionUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            OptionUI.SetActive(false);
            Time.timeScale = 1;
        }
	}

    public void OnClick()
    {
        paused = !paused;
    }

    public void Resume()
    {
        paused = false;
    }
}
