using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WatchVideoHandler : MonoBehaviour {

    public GameObject WatchVideoBtn;
    public GameObject NoThanksBtn;
    public GameObject WatchVideoPannel;

	//public void WatchVideo()
 //   {
 //     //  MonetizationManager.instance.ShowRewardedVideoMediation();
 //       UIManager.Instance.OnWatchVideoSuccessfully.Invoke();
 //   }

 //   public void NoThanksBtnClicked()
 //   {
 //       WatchVideoPannel.transform.GetChild(0).gameObject.transform.DOScale(0f,0.25f).SetEase(Ease.InBounce).SetUpdate(true).OnComplete(delegate {
 //           WatchVideoPannel.SetActive(false);
 //           UIManager.Instance.OnLevelFailedPannelShow();
 //       });
 //   }
}
