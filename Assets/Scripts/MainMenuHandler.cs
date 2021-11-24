using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour {

    [Header("Rate US Links")]
    public string RateUsAndriod = "";
    public string RateUsiOS = "";

    [Header("MoreApp Links")]
    public string MoreAppAndriod = "";
    public string MoreAppiOS = "";

    private bool _onetimeClickSettingButton = true;
    private bool _onetimeClickSocialMedia = true;

    [Header("Canvas Elements")]

    public Button LeaderboardButton;
    public GameObject SettingButton;
    public GameObject Socialmediabutton;
    public GameObject Logo;
    public GameObject PlayButton;
    public GameObject moreButton;
    public GameObject rateButton;
    public GameObject privacyButton;
    public Text NameText;

    [Header("MainMenu Pannels")]

    public GameObject InfoPannel;
    public GameObject TutorialPannel;
    public GameObject ChangeNamePannel;
    public GameObject StorePannel;
    public GameObject LeaderBoardPannel;
    public GameObject LevelSelection;
    public GameObject SettingPanel;
    public GameObject ExitDialog;

    [Header("ScriptableObject")]
    public GameData Gdata;

    public static MainMenuHandler Instance;
    public AudioClip click;

    [Header("Music & Sound")]
    public Button EffectsButton;
    public Button MusicButton;
    public Sprite EffectButtonEnable;
    public Sprite EffectButtonDisable;
    public Sprite MusicButtonEnable;
    public Sprite MusicButtonDisable;

    private bool musicStatus = true;
    private bool effectStatus = true;
    public Text coinText;
    public GameObject level1Panal, level2Panal;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        if (Instance == null)
            Instance = this;
    }

    public void OnEnable()
    {
       // coinText.text = "";
    }
    public void NextLevelp()
    {
        level1Panal.SetActive(false);
        level2Panal.SetActive(true);

    }
    public void PreviousLevelp()
    {
        level1Panal.SetActive(true);
        level2Panal.SetActive(false);
    }


    public void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.GetString("setPlayerName")!= "yes" )
        {
            //ChangeNamePannel.SetActive(true);
            //Logo.gameObject.SetActive(false);
        }
        else
        {
            NameText.text = PlayerPrefs.GetString("PlayerName");
            //UpdatePlayerName(PlayerPrefs.GetString("PlayerName"));

        }
        PlayButton.transform.DOScale(0.70f, 0.55f).SetLoops(-1, LoopType.Yoyo);
        //Logo.transform.DOScale(0.95f, 5f).SetLoops(-1, LoopType.Yoyo);
        //SettingButton.transform.DOScale(0.95f, 0.75f).SetLoops(-1, LoopType.Yoyo);
        //moreButton.transform.DOScale(0.95f, 0.75f).SetLoops(-1, LoopType.Yoyo);
        //rateButton.transform.DOScale(0.95f, 0.75f).SetLoops(-1, LoopType.Yoyo);
        //privacyButton.transform.DOScale(0.95f, 0.75f).SetLoops(-1, LoopType.Yoyo);
        
        SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.MainMenuClip);
        if (SoundManager.Instance.MusicEnabled)
        {
            MusicButton.gameObject.GetComponent<Image>().overrideSprite = MusicButtonEnable;
        }
        else
        {
            MusicButton.gameObject.GetComponent<Image>().overrideSprite = MusicButtonDisable;
        }

        /// sound

        if (SoundManager.Instance.EffectsEnabled)
        {
            EffectsButton.gameObject.GetComponent<Image>().overrideSprite = EffectButtonEnable;
        }
        else
        {
            EffectsButton.gameObject.GetComponent<Image>().overrideSprite = EffectButtonDisable;
        }

        SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.MainMenuClip);
        //NameText.text = PlayFabManager.Instance.Gdata.PlayerName;
        // Logo.transform.DOScale(0.9f, 4f).SetLoops(-1, LoopType.Yoyo);
    }


    public void OnLeaderboardReadyToShow()
    {
        LeaderboardButton.interactable = true;
    }

    public void PlayButtonClick()
    {
        //AdsManager.instance.Show_AdmobInterstitial();
        // AdsScript.instance.ShowInterstitial();
        LevelSelection.SetActive(true);
        Logo.SetActive(false);
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
    }

    public void SettingsButtonClick()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
        SettingPanel.SetActive(true);
        Socialmediabutton.SetActive(false);
        InfoPannel.SetActive(false);
        Logo.gameObject.SetActive(false);
        ChangeNamePannel.gameObject.SetActive(false);
        //if (_onetimeClickSettingButton)
        //{
        //    _onetimeClickSettingButton = false;
        //    StartCoroutine(CountDownSettingButtonON());
        //}
        //else
        //{
        //    _onetimeClickSettingButton = true;
        //    StartCoroutine(CountDownSettingButtonOFF());
        //}
        //SoundManager.Instance.PlayEffect(AudioClipsSource.Instance._ButtonClick);

    }
  
    public void Cross()
    {
        Logo.gameObject.SetActive(true);
        SettingPanel.SetActive(false);
        InfoPannel.SetActive(false);
        Socialmediabutton.SetActive(false);
        LevelSelection.SetActive(false);
    }

    public void ShareButtonClick()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
        Socialmediabutton.SetActive(true);
        SettingButton.SetActive(false);
        InfoPannel.SetActive(false);
        ChangeNamePannel.gameObject.SetActive(false);
        //if (_onetimeClickSocialMedia)
        //{
        //    _onetimeClickSocialMedia = false;
        //    StartCoroutine(CountDown());
        //}
        //else
        //{
        //    _onetimeClickSocialMedia = true;
        //    StartCoroutine(CountDownSocialMediaOff());

        //}
        //SoundManager.Instance.PlayEffect(AudioClipsSource.Instance._ButtonClick);

    }

    private IEnumerator CountDownSocialMediaOff()
    {
        Socialmediabutton.GetComponent<Button>().enabled = false;
        var length = Socialmediabutton.transform.childCount;
        for (var i = length; i > 0; i--)
        {
            Socialmediabutton.transform.GetChild(i - 1).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);
        }
        Socialmediabutton.GetComponent<Button>().enabled = true;

    }

    private IEnumerator CountDown()
    {
        Socialmediabutton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(0.05f);
        var length = Socialmediabutton.transform.childCount;
        for (var i = 0; i < length; i++)
        {
            Socialmediabutton.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.05f);


        }
        Socialmediabutton.GetComponent<Button>().enabled = true;
    }

    private IEnumerator CountDownSettingButtonON()
    {
        SettingButton.GetComponent<Button>().enabled = false;

        yield return new WaitForSeconds(0.05f);
        var length = SettingButton.transform.childCount;
        for (var i = 0; i < length; i++)
        {
            SettingButton.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        SettingButton.GetComponent<Button>().enabled = true;
    }

    public IEnumerator CountDownSettingButtonOFF()
    {
        SettingButton.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(0.05f);
        var length = SettingButton.transform.childCount;
        for (var i = length; i > 0; i--)
        {
            SettingButton.transform.GetChild(i - 1).gameObject.SetActive(false);
            yield return new WaitForSeconds(0.05f);
        }
        SettingButton.GetComponent<Button>().enabled = true;
    }

    public void SoundOnOffButtonClick()
    {

    }

    public void MusicOnOffButtonClick()
    {

    }

    public void Fb()
    {
        Application.OpenURL("https://www.facebook.com/ingeniousc");
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/IngeniousConce3");
    }

    public void YouTube()
    {
    }

    public void Privacy()
    {
        Application.OpenURL("https://sites.google.com/view/hadi-technologies/home");
    }

    public void TutorialButtonClick()
    {
        TutorialPannel.SetActive(true);
      //  TutorialPannel.transform.GetChild(0).gameObject.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce);
    }

    public void InfoButtonClick()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
        InfoPannel.SetActive(true);
        SettingPanel.SetActive(false);
        Socialmediabutton.SetActive(false);
        ChangeNamePannel.gameObject.SetActive(false);
        InfoPannel.transform.GetChild(0).gameObject.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).OnComplete(delegate
        {
            InfoPannel.GetComponent<InfoPannelHandler>().OnInfoPannelOpen();
        });
    }

    public void ExitButtonClick()
     {

        Logo.SetActive(false);
        ExitDialog.SetActive(true);
    }
    public void Yes()
    {
        Application.Quit();
    }

    public void No()
    {
        ExitDialog.SetActive(false);
        Logo.SetActive(true);
    }
    public void ChangeNameButtonClick()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
        ChangeNamePannel.SetActive(true);
        Logo.gameObject.SetActive(false);
        //  ChangeNamePannel.transform.GetChild(0).transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce);
    }

    public void UpdatePlayerName(string playerName)
    {
       
            NameText.text = playerName;
            Gdata.PlayerName = playerName;
            Gdata.SetPlayerName = true;
            PlayerPrefs.SetString("PlayerName", playerName);

        
        
    }

    public void MoreGamesButtonClick()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
#if UNITY_ANDROID
        Application.OpenURL(MoreAppAndriod);
#elif UNITY_IOS
          Application.OpenURL(MoreAppiOS); 
#endif
    }

    public void RateUsButtonClick()
    {
#if UNITY_ANDROID
        Application.OpenURL(RateUsAndriod);
#elif UNITY_IOS
          Application.OpenURL(RateUsiOS); 
#endif
    }

 

    public void LeaderBoardButtonClick()
    {
        LeaderBoardPannel.transform.parent.gameObject.SetActive(true);
       // LeaderBoardPannel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce);
    }

    public void StoreButtonClick()
    {
        StorePannel.SetActive(true);
      //  StorePannel.transform.GetChild(0).gameObject.transform.DOScale(1f, 0.5f).SetEase(Ease.OutBounce);
    }

    public void EffectsEnable()
    {

        effectStatus = !effectStatus;

        if (EffectButtonEnable == null && EffectButtonDisable == null)
            return;

        if (effectStatus)
        {
            EffectsButton.gameObject.GetComponent<Image>().overrideSprite = EffectButtonEnable;
        }
        else
        {
            EffectsButton.gameObject.GetComponent<Image>().overrideSprite = EffectButtonDisable;
        }
        SoundManager.Instance.EffectsEnabled = effectStatus;
        Debug.Log("Effects Status" + effectStatus);
    }

    public void MusicEnable()
    {
        musicStatus = !musicStatus;


        if (MusicButtonEnable == null && MusicButtonDisable == null)
            return;

        if (musicStatus)
        {
            MusicButton.gameObject.GetComponent<Image>().overrideSprite= MusicButtonEnable;
        }
        else
        {
            MusicButton.gameObject.GetComponent<Image>().overrideSprite = MusicButtonDisable;
        }

        SoundManager.Instance.MusicEnabled = musicStatus;
        Debug.Log("Music Status" + musicStatus);

    }

    public void SettingBtn()
    {

        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
       
        Logo.gameObject.SetActive(false);
       
        OnGameSettingPannelShow();

    }

    public void OnGameSettingPannelShow()
    {
        SettingPanel.SetActive(true);  
        SettingPanel.transform.GetChild(0).gameObject.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).OnComplete(delegate
        {
            SettingPanel.GetComponent<SettingPannelHandler>().OnSettingPannelOpen();
        });
    }

    public void Shop()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.PlayButtonClick);
        SceneManager.LoadScene("Shop");

    }

   
}


