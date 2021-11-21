using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PausePannelHandler : MonoBehaviour {

    [Header("Pause Pannel Buttons")]
    public GameObject Resume;
    public GameObject Restart;
    public GameObject MainMenu;


	public void OnPausePannelOpen()
    {
        Debug.Log("HELLOOO");

        Resume.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
        {
            MainMenu.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
            {
                Restart.transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce).SetUpdate(true).OnComplete(delegate
                {
                });

            });

        });
    }

    public void OnPausePannelClose()
    {
        Resume.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
        Restart.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
        MainMenu.transform.DOScale(0f, 0.1f).SetEase(Ease.OutBounce).SetUpdate(true);
             
    }


}
