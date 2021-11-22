using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public static UiManager Instance = null;

    [HideInInspector]
    public UnityEvent OnLevelFailed;

    [HideInInspector]
    public UnityEvent OnLevelCompleted;

    [HideInInspector]
    public UnityEvent OnGamePause;

    [Header("GameScreens")]
    public GameObject PauseScreen;
    public GameObject LevelFailedScreen;
    public GameObject LevelCompleteScreen;
    public GameObject KidDialogue;
    public Text KidDialogueText;
    [Header("Other Objects")]
    public GameObject TimerObject;
    public GameObject NightVisionEffect;
    private bool levelupcheck = false;
    public GameObject fireButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    public void Exitgame()
    {
        Application.Quit();
    }

    private void Start()
    {
        Debug.Log("Selectedlevel ="+ GameManager.Instance.SelectedLevel);

        OnLevelFailed.AddListener(delegate
        {
            //AdsManager.instance.Show_AdmobInterstitial();
            //AdsManager.instance.Show_AdmobBanner();
            // AdsScript.instance.ShowInterstitial();
            // AdsScript.instance.ShowTopCentertBanner();
            LevelFailedScreen.SetActive(true);
//            AnaabiTechAds.Instance.ShowVideoAd();
            //LevelFailedScreen.GetComponent<levelFailedHandler>().AppearBtns();
            //TimerObject.GetComponent<TimerScript>().LevelCompleteOrFailed = true;

        });

        OnLevelCompleted.AddListener(delegate
        {
            //AdsManager.instance.Show_AdmobInterstitial();
            //AdsManager.instance.Show_AdmobBanner();
            //SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.ScreemTeacher);
          //  AnaabiTechAds.Instance.ShowVideoAd();
            // AdsScript.instance.ShowInterstitial();
            // AdsScript.instance.ShowTopCentertBanner();
            LevelCompleteScreen.SetActive(true);
            //TimerObject.GetComponent<TimerScript>().LevelCompleteOrFailed = true;

            //LevelCompleteScreen.GetComponent<LevelCompleteHandler>().AppearBtns();

            if (!levelupcheck)
            {
                levelupcheck = true;
                
                if (PlayerPrefs.GetInt("UnlockLevel") < GameManager.Instance.SelectedLevel+1)
                {
                    PlayerPrefs.SetInt("UnlockLevel", GameManager.Instance.SelectedLevel+1);
                }
            }
        });

        OnGamePause.AddListener(delegate
        {
            PauseScreen.SetActive(true);

        });

    }



    public void OnPauseButtonPressed()
    {
        //AdsManager.instance.Show_AdmobInterstitial();
        //AdsManager.instance.Show_AdmobBanner();
        OnGamePause.Invoke();
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
     //   AnaabiTechAds.Instance.ShowInterstitial();

    }

    public void OnMainMenuClick()
    {
        //AdsManager.instance.Destroy_AdmobBanner();
        // AdsScript.instance.HideTopCenterBanner();
        Time.timeScale = 1f;
        GameManager.Instance.ChangeScene("MainMenu");
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
      //  AnaabiTechAds.Instance.ShowInterstitial();

    }

    public void OnResumeButtonClick()
    {
        //AdsManager.instance.Destroy_AdmobBanner();
        // AdsScript.instance.HideTopCenterBanner();
        PauseScreen.SetActive(false);
        Time.timeScale = 1;
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);

    }


    public void OnlevelupNext()
    {
        //AdsManager.instance.Destroy_AdmobBanner();
        // AdsScript.instance.HideTopCenterBanner();
        GameManager.Instance.SelectedLevel += 1;
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);        
        // GameManager.Instance.ChangeScene("Gameplay");
        if(GameManager.Instance.SelectedLevel <= 10)
        {
        GameManager.Instance.ChangeScene("Gameplay");
        }
        else if(GameManager.Instance.SelectedLevel == 11)
        {
        GameManager.Instance.ChangeScene("MainMenu");
        }
        
     //   AnaabiTechAds.Instance.ShowVideoAd();

    }

    public void OnLevelRestart()
    {
       //AdsManager.instance.Destroy_AdmobBanner();
        // AdsScript.instance.HideTopCenterBanner();
        Time.timeScale = 1f;
        GameManager.Instance.ChangeScene("Loading");
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
    //    AnaabiTechAds.Instance.ShowInterstitial();
    }

    public void KidDialogueShow()
    {
       
        StartCoroutine("PlayText");
        KidDialogue.SetActive(true);
    }
    public void KidDialogueOFF()
    {
        KidDialogue.SetActive(false);
        

    }
    public void EnableNightMode()
    {
        NightVisionEffect.SetActive(true);
    }
    IEnumerator PlayText()
    {
        string story = KidDialogueText.text;
        KidDialogueText.text = "";
        foreach (char c in story)
        {
            KidDialogueText.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }

    public void showFireButton()
    {
        fireButton.SetActive(true);
    }
}
