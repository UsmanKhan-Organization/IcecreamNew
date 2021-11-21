using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingScriptHandler : MonoBehaviour {

    [Header("Loading UI Elements")]
    public Image LoadingBar = null;
    public Text LoadingProgress = null;

    void LoadLeve(int sceneIndex)
    {
        //LoadAsychronously
    }


    private void Start()
    {
        //AdsManager.instance.Show_AdmobInterstitial();
        // AdsScript.instance.ShowInterstitial();
        StartCoroutine(LoadAsychronously("GamePlay"));

    }

    IEnumerator LoadAsychronously(string sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadingBar.fillAmount = progress;
            LoadingProgress.text = progress * 100f + "%";
            //Debug.Log(operation.progress);

            yield return null;
        }
    }
}
