using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PrivacyPolicyController : MonoBehaviour
{

    /// <summary>
    /// Main Script that deals with the Privacy Policy Related Funtions, It Doesn't Required MonoBehaviour.
    /// 
    /// </summary>
    public string PrivacyPolicyLink = "";
    //   public UnityEvent OnContinueEvent;
    public void Start()
    {
        
        if (PlayerPrefs.GetInt("PolicyAgreed") == 1)
        {
			Application.LoadLevel(Application.loadedLevel + 1);
            gameObject.SetActive(false);            
        }
    }


    public void OnClickQuitButton()
    {

        Application.Quit();
    }


    public void OnClickContinueButton()
    {
        //if (OnContinueEvent!=null)
        //{
        //    OnContinueEvent.Invoke();

        //}

        Application.LoadLevel(Application.loadedLevel + 1);
             
        PlayerPrefs.SetInt("PolicyAgreed", 1);
        gameObject.SetActive(false);
    }

    public void OnClickPrivayButton()
    {
        Application.OpenURL(PrivacyPolicyLink);
    }

}
