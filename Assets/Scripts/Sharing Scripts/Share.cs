using UnityEngine;
public class Share : MonoBehaviour
{
    public string _body;

    public void ShareSimpleText()
    {
        //_body = "Play Captain Jatt! Beat Me At Leaderboard. \n http://www.ultpult.com/games/captain-jatt.html";

#if UNITY_ANDROID && !UNITY_EDITOR

        //Refernece of AndroidJavaClass class for intent
        var intentClass = new AndroidJavaClass("android.content.Intent");
        //Refernece of AndroidJavaObject class for intent
        var intentObject = new AndroidJavaObject("android.content.Intent");
        //call setAction method of the Intent object created
        intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
        //set the type of sharing that is happening
        intentObject.Call<AndroidJavaObject>("setType", "text/plain");
        //add data to be passed to the other activity i.e., the data to be sent
        //intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), _body);
        //get the current activity
        var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

        var jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");

        //start the activity by sending the intent data
        currentActivity.Call("startActivity", jChooser);
#elif UNITY_IOS
        GeneralSharingiOSBridge.ShareSimpleText (_body);
#endif
    }
}