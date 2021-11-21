using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WeaponSelectionHandler : MonoBehaviour {

    [Header("Lock Objects")]
    public GameObject[] LockObjs = null;
    [Header("Level Objects")]
    public GameObject[] LevelObjs = null;
    public Button select;
    public Button unlock;
    public int lockedWeapon = 0;
    private GameObject[] weaponsList;
    private int index;
    public int[] coins;
    public string[] guns = { "ak47","m4", "sniper", "shotgun", "mp5"};
    public GameObject noCoins;

    //[Header("Level Unlock Value")]
    [HideInInspector]
    public int LvlUnlocked=1;


	public void UnlockLevels()
    {
        //LvlUnlocked = PlayerPrefs.GetInt("unlockedWeapon");
        for (int i = 1; i < LvlUnlocked; i++)
        {
            LockObjs[i-1].SetActive(false);
            LevelObjs[i].GetComponent<Button>().interactable = true;

           

        }
    }


    // Use this for initialization
    void Start () {

        weaponsList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weaponsList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in weaponsList)
        {
            go.SetActive(false);
        }

        if (weaponsList[0])
            weaponsList[0].SetActive(true);

        SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.LevelSelectionClip);
       
    }
	

    public void NextButtonClick()
    {
        GameManager.Instance.ChangeScene("Loading");
    }

    public void BackButtonClick()
    {
        GameManager.Instance.ChangeScene("MainMenu");

    }

    public void LevelButtonPressed(int val)
    {
        NextButtonClick();
    }

    public void ToggleLeft()
    {
        weaponsList[index].SetActive(false);

        index--;
       

        if (index < 0)
            index = weaponsList.Length - 1;

        //if (LockObjs[index].activeSelf)
        //{
        //    select.gameObject.SetActive(false);
        //    unlock.gameObject.SetActive(true);
        //}     
        //else
        //{
        //    select.gameObject.SetActive(true);
        //    unlock.gameObject.SetActive(false);
        //}

        WeaponSwitch();
        weaponsList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        weaponsList[index].SetActive(false);

        index++;
        //int temp = PlayerPrefs.GetInt("guns");

        if (index == weaponsList.Length)
            index = 0;
        //if (index < temp)
        //{
        //    select.gameObject.SetActive(true);
        //    unlock.gameObject.SetActive(false);
        //}
        //else
        //{
        //    select.gameObject.SetActive(false);
        //    unlock.gameObject.SetActive(true);
        //}

        WeaponSwitch();


        weaponsList[index].SetActive(true);
    }

    public void WeaponSwitch()
    {
        switch (guns[index])
        {
            case "ak47":
                select.gameObject.SetActive(true);
                unlock.gameObject.SetActive(false);
                break;
            case "m4":
                if (PlayerPrefs.GetInt("m4") == 1)
                {
                    select.gameObject.SetActive(true);
                    unlock.gameObject.SetActive(false);
                    LockObjs[index].SetActive(false);
                }
                else
                {
                    select.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                    LockObjs[index].SetActive(true);
                }

                break;
            case "sniper":
                if (PlayerPrefs.GetInt("sniper") == 1)
                {
                    select.gameObject.SetActive(true);
                    unlock.gameObject.SetActive(false);
                    LockObjs[index].SetActive(false);
                }
                else
                {
                    select.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                    LockObjs[index].SetActive(true);
                }

                break;
            case "shotgun":
                if (PlayerPrefs.GetInt("shotgun") == 1)
                {
                    select.gameObject.SetActive(true);
                    unlock.gameObject.SetActive(false);
                    LockObjs[index].SetActive(false);
                }
                else
                {
                    select.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                    LockObjs[index].SetActive(true);
                }

                break;
            case "mp5":
                if (PlayerPrefs.GetInt("mp5") == 1)
                {
                    select.gameObject.SetActive(true);
                    unlock.gameObject.SetActive(false);
                    LockObjs[index].SetActive(false);
                }
                else
                {
                    select.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                    LockObjs[index].SetActive(true);
                }

                break;
        }
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("WeaponSelected", index);
        SceneManager.LoadScene("LevelSelection");
    }

    //public void Unlock()
    //{
    //    if (coins[index] <= DBManager.GetFunds("coins"))
    //    {
    //        switch (guns[index])
    //        {
    //            case "ak47":

    //                break;
    //            case "m4":
    //                PlayerPrefs.SetInt("m4", 1);
    //                break;
    //            case "sniper":
    //                PlayerPrefs.SetInt("sniper", 1);
    //                break;
    //            case "shotgun":
    //                PlayerPrefs.SetInt("shotgun", 1);
    //                break;
    //            case "mp5":
    //                PlayerPrefs.SetInt("mp5", 1);
    //                break;
    //        }
    //        select.gameObject.SetActive(true);
    //        unlock.gameObject.SetActive(false);
    //        DBManager.SetFunds("coins", DBManager.GetFunds("coins") - coins[index]);
    //        LockObjs[index].SetActive(false);
    //    }
    //    else
    //        noCoins.SetActive(true);
    //}

    public void Ok()
    {
        noCoins.SetActive(false);
    }


}
