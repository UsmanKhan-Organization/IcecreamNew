using UnityEngine;

public class CompanyInfo : MonoBehaviour
{
	[Header("Company Social Media Info")]
	public string FacebookLink;
	public string TwitterLink;
	public string YoutubeLink;

	public string FacebookPageNumber;
	public string TwitterPageId;

    public void LikeUsFaceBook()
    {
		if (FacebookLink == null && FacebookPageNumber == null)
			return;


#if UNITY_ANDROID
        if (checkPackageAppIsPresent("com.facebook.katana"))
        {
            //Application.OpenURL("fb://page/817905344994032");
			Application.OpenURL("fb://page/"+FacebookPageNumber);
		}
        else
        {
			Application.OpenURL(FacebookLink);
        }
#else
		//int testfb = CheckAppExistPlugin.CheckFBPresent ();
		//if (testfb == 1) {
		////Application.OpenURL ("fb://profile/817905344994032");
		//Application.OpenURL ("fb://profile/"+FacebookPageNumber);
		//} else {
		//Application.OpenURL (FacebookLink); // no Facebook app - use built-in web browser
		//}
		#endif
    }
		

    public void LikeUsTwitter()
    {
		if (TwitterLink == null && TwitterPageId == null)
			return;

#if UNITY_ANDROID
        if (checkPackageAppIsPresent("com.twitter.android"))
        {
            //Application.OpenURL("twitter://user?user_id=4483116743");
			Application.OpenURL("twitter://user?user_id="+TwitterPageId);
        }
        else
        {
			Application.OpenURL(TwitterLink);
        }
#else
		//int testTwitter = CheckAppExistPlugin.CheckTwitterPresent ();
		//if (testTwitter == 1) {
		////Application.OpenURL ("twitter://user?user_id=4483116743");
		//Application.OpenURL("twitter://user?user_id="+TwitterPageId);
		//} else {
		//Application.OpenURL(TwitterLink);
		//}

		#endif
    }

    public void LikeUsYoutube()
    {
		if (YoutubeLink == null)
			return;

#if UNITY_ANDROID
        if (checkPackageAppIsPresent("com.google.android.youtube"))
        {
			Application.OpenURL(YoutubeLink);
        }
        else
        {
			Application.OpenURL(YoutubeLink);
        }
#else
		//int testYoutube = CheckAppExistPlugin.CheckYoutubePresent ();
		//if (testYoutube == 1) {
		//Application.OpenURL(YoutubeLink);
		//} else {
		//Application.OpenURL(YoutubeLink); 
		//}

		#endif
    }

    private bool checkPackageAppIsPresent(string package)
    {
        var up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var ca = up.GetStatic<AndroidJavaObject>("currentActivity");
        var packageManager = ca.Call<AndroidJavaObject>("getPackageManager");
        var appList = packageManager.Call<AndroidJavaObject>("getInstalledPackages", 0);
        var num = appList.Call<int>("size");
        for (var i = 0; i < num; i++)
        {
            var appInfo = appList.Call<AndroidJavaObject>("get", i);
            var packageNew = appInfo.Get<string>("packageName");

            if (packageNew.CompareTo(package) == 0)
            {
                return true;
            }
        }
        return false;
    }
}