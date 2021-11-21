using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPressPause : MonoBehaviour {

    private bool pause;
    public GameObject pauseMenu;
    


    // Use this for initialization
    void Start () {
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            PauseMenu();
        }
		
	}

    void PauseMenu()
    {
        pause = !pause;

        if (pause)
        {
            pauseMenu.SetActive(false);
            

            Time.timeScale = 1;
        }
        else if (!pause)
        {
            
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

    }

}
