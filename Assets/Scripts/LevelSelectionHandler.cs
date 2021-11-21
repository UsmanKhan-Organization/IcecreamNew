using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionHandler : MonoBehaviour {

    [Header("Lock Objects")]
    public GameObject[] LockObjs = null;
    [Header("Level Objects")]
    public GameObject[] LevelObjs = null;

    //[Header("Level Unlock Value")]
    [HideInInspector]
    public int LvlUnlocked=1;


	public void UnlockLevels()
    {
        for(int i = 1; i < LvlUnlocked; i++)
        {
            LockObjs[i - 1].SetActive(false);
            LevelObjs[i].GetComponent<Button>().interactable = true;

        }
    }


    // Use this for initialization
    void Start () {
        SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.LevelSelectionClip);
        int levelUnlock = PlayerPrefs.GetInt("UnlockLevel");
        if (levelUnlock <= 15)
        {
            LvlUnlocked = levelUnlock;
        }
        else
        {
            LvlUnlocked = 15;
        }

        UnlockLevels();

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
        GameManager.Instance.SelectedLevel = val;
        NextButtonClick();
    }
}
