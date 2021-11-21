using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour {

    private bool isExit;
    public GameObject exitDialog;
    public GameObject logo;
    public GameObject infoPanel;
    public GameObject settingPanel;

    // Use this for initialization
    void Start () {
        isExit = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.Escape))
        {
            //  LightboltMonetization.instance.ShowInterstitialMediation();
            ExitDialog();
        }
		
	}

    void ExitDialog()
    {
        isExit = !isExit;

        if (!isExit)
        {
            exitDialog.SetActive(true);
            logo.SetActive(false);
            infoPanel.SetActive(false);
            settingPanel.SetActive(false);
        } else
              if (isExit)
        {
            exitDialog.SetActive(false);
            logo.SetActive(true);
        }
        

    }

    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        exitDialog.SetActive(false);
        logo.SetActive(true);
    }
}
