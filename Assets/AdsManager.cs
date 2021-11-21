using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour 
{

     public static AdsManager instance = null;

    [Header("Unity")]
    [Space(2)]
    public string androidID = "1486550";
    public string iOSID = "1486551";
    string RewardedPlacementId = "rewardedVideo";
    string placementId = "video";

    [Header("Admob Android ID's")]
    [Space(2)]
    public string appId = "";
    public string bannerID = "";
    public string interstitialID = "";
    public string rewardedVideoID = "";
    public string nativeBannerID = "";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;


    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        //Unity Stuff
#if UNITY_ANDROID || UNITY_EDITOR
        Advertisement.Initialize(androidID);
#elif UNITY_IOS
		Advertisement.Initialize (iOSID);
#endif
        //admob Init
        MobileAds.Initialize(appId);

        RequestInterstitial();
        RewardedVideo_AdRequest();

        DontDestroyOnLoad(gameObject);
    }
    void Init_IDs() 
    {

#if UNITY_IOS
     //   		 appID="ca-app-pub-3940256099942544~1458002511";
				 //bannerID="ca-app-pub-3940256099942544/2934735716";
				 //interstitialID="ca-app-pub-3940256099942544/4411468910";
				 //videoID="ca-app-pub-3940256099942544/1712485313";
				 //nativeBannerID = "ca-app-pub-3940256099942544/3986624511";
#elif UNITY_ANDROID

        //appID = "ca-app-pub-3940256099942544~3347511713";
        //bannerID = "ca-app-pub-3940256099942544/6300978111";
        //interstitialID = "ca-app-pub-3940256099942544/1033173712";
        //videoID = "ca-app-pub-3940256099942544/5224354917";
        //nativeBannerID = "ca-app-pub-3940256099942544/2247696110";
#endif
    }


    //Unity Stuff
    public void Show_UnityRewardedVideo()
    {

        if (Advertisement.IsReady(RewardedPlacementId))
        {
            var options = new ShowOptions { resultCallback = HandleShowResultForRewardedVideo };
            Advertisement.Show(RewardedPlacementId, options);
        }
         
    }
      
    public void Show_UnityIntertitial()
    {
        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
        }

    }
      
    private void HandleShowResultForRewardedVideo(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

    //Admob Stuff
    private void RequestBanner()
    {

//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
//#elif UNITY_IPHONE
//            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
//#else
//        string adUnitId = "unexpected_platform";
//#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(bannerID, AdSize.Banner, AdPosition.Top);

        //CallBack Events
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    public void Show_AdmobBanner()
    {
        RequestBanner();
    }

    //Destroy admob Banner
    public void Destroy_AdmobBanner()
    {
        bannerView.Destroy();
    }

    //Request admob Interstitial
    private void RequestInterstitial()
    {
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
//#else
//        string adUnitId = "unexpected_platform";
//#endif

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(interstitialID);

        //CallBack Events
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }
    public void Show_AdmobInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            Show_UnityIntertitial();
        }
    }
     
    //Call Back Functions for admob banner and interstitial
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
        RequestInterstitial();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

    //Request Admob Rewarded Video
    private void RewardedVideo_AdRequest()
    {
//        string adUnitId;
//#if UNITY_ANDROID
//        adUnitId = "ca-app-pub-3940256099942544/5224354917";
//#elif UNITY_IPHONE
//            adUnitId = "ca-app-pub-3940256099942544/1712485313";
//#else
//            adUnitId = "unexpected_platform";
//#endif

        this.rewardedAd = new RewardedAd(rewardedVideoID);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void Show_AdmobRewarded_Video()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
        RewardedVideo_AdRequest();

    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
        RewardedVideo_AdRequest();

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RewardedVideo_AdRequest();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
 
    }
}
