using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialPannelHandler : MonoBehaviour {
    public GameObject TutorialPannel;
    public GameObject TutorialScreens;

    private int TutorialCheck = 0;

    public void TutorialScreenRightBtnClick()
    {
        if (TutorialCheck < 4)
        {
            TutorialScreens.transform.GetChild(TutorialCheck).transform.gameObject.SetActive(false);
            TutorialScreens.transform.GetChild(TutorialCheck + 1).transform.gameObject.SetActive(true);
            TutorialCheck += 1;
            Debug.Log("Tutorial check if condition" + TutorialCheck);

        }
        else
        {
            Debug.Log("ksdgfjksdfgsjkfgk");
            TutorialCheck = 0;
            TutorialScreens.transform.GetChild(TutorialCheck).transform.gameObject.SetActive(true);
            TutorialScreens.transform.GetChild(TutorialScreens.transform.childCount-1).transform.gameObject.SetActive(false);
        }
        Debug.Log(TutorialCheck);
        

    }

    public void TutorialScreenLeftBtnClick()
    {
        //if (TutorialCheck < 4)
        //{
            TutorialScreens.transform.GetChild(TutorialCheck).transform.gameObject.SetActive(false);
            TutorialScreens.transform.GetChild(TutorialCheck + 1).transform.gameObject.SetActive(true);
            TutorialCheck += 1;
            Debug.Log("Tutorial check if condition" + TutorialCheck);

        //}
        //else
        //{
        //    Debug.Log("ksdgfjksdfgsjkfgk");
        //    TutorialCheck = 0;
        //    TutorialScreens.transform.GetChild(TutorialCheck).transform.gameObject.SetActive(true);
        //    TutorialScreens.transform.GetChild(TutorialScreens.transform.childCount - 1).transform.gameObject.SetActive(false);
        //}
        //Debug.Log(TutorialCheck);


    }


    public void TutorialCloseBtnClick()
    {
        TutorialCheck = 0;
        for(int i = 0; i < TutorialScreens.transform.childCount; i++)
        {
            TutorialScreens.transform.GetChild(i).transform.gameObject.SetActive(false);

        }
        TutorialScreens.transform.GetChild(0).transform.gameObject.SetActive(true);
        TutorialScreens.transform.parent.gameObject.transform.DOScale(0f, 0.35f).SetEase(Ease.OutBack).OnComplete(delegate
        {
            TutorialPannel.SetActive(false);

        });

    }

}
