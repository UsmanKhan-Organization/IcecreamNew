using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class InfoPannelHandler : MonoBehaviour {


    [Header("Pause Pannel Buttons")]
    public GameObject fb;
    public GameObject twitter;
    public GameObject youtube;
    public GameObject back;

    public Image Logo;
    public GameObject InfoPannel;
    public GameObject ChangeNamePannel;
    public GameObject SettingPanel;


    public void OnInfoPannelOpen()
    {
        Debug.Log("HELLOOO");

        fb.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            twitter.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                youtube.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {

                    back.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                    {
                    });

                });

            });

        });
    }

    public void OnInfoPannelClose()
    {
        fb.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
        twitter.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
        youtube.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
        Logo.gameObject.SetActive(true);
        SettingPanel.SetActive(false);
        InfoPannel.SetActive(false);


    }


}
