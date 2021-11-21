using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenIceCreamDoor : MonoBehaviour {

    public Animator[] doorAnimation;
    public Collider doorCol;
    public bool CanOpenDoor;
    public bool isIceCreamDoor;
    public static OpenIceCreamDoor instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        // just for ice cream shop
        if (isIceCreamDoor && CanOpenDoor)
        {
            
            opendoors();
        }

        if (!isIceCreamDoor)
        {
            for(int i =0; i< doorAnimation.Length;i++)
            doorAnimation[i].enabled = true;
        }
    }

    //for icecream shop only
    void opendoors()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.openDoor);
        print("enter ice cream shop");
        for (int i = 0; i < doorAnimation.Length; i++)
            doorAnimation[i].enabled = true;
       
    }

}
