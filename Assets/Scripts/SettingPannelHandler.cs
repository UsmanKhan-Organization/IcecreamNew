using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingPannelHandler : MonoBehaviour {

    [Header("Pause Pannel Buttons")]
    public GameObject music;
    public GameObject sound;
    public GameObject info;
    public GameObject back;

    public GameObject Logo;
    public GameObject InfoPannel;
    public GameObject ChangeNamePannel;
    public GameObject SettingPanel;


    public void OnSettingPannelOpen()
    {
        Debug.Log("HELLOOO");

        music.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            sound.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                info.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {

                    back.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                    {
                    });


                });

            });

        });
    }

    public void OnSettingPannelClose()
    {
        music.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
        sound.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
       
        Logo.gameObject.SetActive(true);
        SettingPanel.SetActive(false);
       
      

    }


}
