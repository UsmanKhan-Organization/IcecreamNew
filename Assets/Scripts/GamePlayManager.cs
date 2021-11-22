using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    public LevelSetting[] MyLevelSetting;
    public GameObject Alliey;
    //public GameObject Arrow;
    public GameObject Player,canVas;

    public GameObject TimerObject, icecreamMan,icecreamManGhost;

    public GameObject level2WalletPos, level6WalletPos, level9WalletPos;
    public GameObject dialogueCam, mainCam, level4objects, garageButton, vanDoor, garageWall;



    public static GamePlayManager instance;


    private void Awake()
    {
        DOTween.Init();

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public int lvlnumber = 0;

    public IEnumerator Delay()
    {
        dialogueCam.SetActive(true);
        // mainCam.SetActive(false);
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.grab);
        PlayerManager.instance.Kidlevel10.GetComponent<Animator>().SetTrigger("free");
        UiManager.Instance.KidDialogueShow();
        yield return new WaitForSeconds(8f);
        UiManager.Instance.KidDialogueOFF();
        PlayerManager.instance.Kidlevel10.SetActive(false);
        // mainCam.SetActive(true);
        dialogueCam.SetActive(false);
        level4objects.SetActive(true);

    }
    private void Start()
    {
        
       
        lvlnumber = GameManager.Instance.SelectedLevel-1; 
        //ObjectiveHandler.Instance.WriteText(ObjectiveHandler.Instance.ObjectiveDescriptions[lvlnumber]);
        //SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.MainMenuClip);
        // if(GameManager.Instance.SelectedLevel <= 7)
        // {
        //     canVas.SetActive(true);
        // }
        
        if(GameManager.Instance.SelectedLevel == 2)
        {
            MyLevelSetting[1].Objects[0].transform.position = level2WalletPos.transform.position;
        }
        
        
        else if(GameManager.Instance.SelectedLevel == 6)
        {
            MyLevelSetting[5].Objects[0].transform.position = level6WalletPos.transform.position;
        }
        
        
        else if(GameManager.Instance.SelectedLevel == 9)
        {
            MyLevelSetting[8].Objects[0].transform.position = level9WalletPos.transform.position;
        }

    }

    public void StartLevelSettings()
    {
        
        //SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.GenericButtonClip);
        //SoundManager.Instance.PlayBackgroundMusic(AudioClipsSource.Instance.GamePlayClip);

        //TimerObject.SetActive(true);
        if (GameManager.Instance.SelectedLevel >=2 && GameManager.Instance.SelectedLevel <=10)
        {
            icecreamMan.SetActive(true);
        }
        
        //else if(GameManager.Instance.SelectedLevel == 6)
        //{
        //    icecreamManGhost.SetActive(true);
        //}
        //else if (GameManager.Instance.SelectedLevel >=7 && GameManager.Instance.SelectedLevel <=12 )
        //{
        //    icecreamMan.SetActive(true);
        //}
        //if(GameManager.Instance.SelectedLevel >= 13)
        //{
        //    icecreamManGhost.SetActive(true);
        //    StartCoroutine(ManEnableDelay());
        //}
        //TimerObject.GetComponent<TimerScript>().timeLeft = MyLevelSetting[lvlnumber].LevelTime;


        MyLevelSetting[lvlnumber].wayPoint.SetActive(true);
        for (int i = 0; i <= MyLevelSetting[lvlnumber].HelpingArrows.Length - 1; i++)
        {
            //MyLevelSetting[lvlnumber].HelpingArrows[i].transform.localPosition = MyLevelSetting[lvlnumber].HelpArrowsPosition[i].transform.localPosition;
            //MyLevelSetting[lvlnumber].HelpingArrows[i].transform.localRotation = MyLevelSetting[lvlnumber].HelpArrowsPosition[i].transform.localRotation;

            MyLevelSetting[lvlnumber].HelpingArrows[i].GetComponent<ArrowMomentScript>().Position = MyLevelSetting[lvlnumber].HelpingArrowAnimatePositions[i];
            MyLevelSetting[lvlnumber].HelpingArrows[i].SetActive(true);

        }

        for (int i = 0; i <= MyLevelSetting[lvlnumber].Objects.Length - 1; i++)
        {
            MyLevelSetting[lvlnumber].Objects[i].SetActive(true);
        }
        for (int i = 0; i <= MyLevelSetting[lvlnumber].EnvironemtnObjects.Length - 1; i++)
        {
            MyLevelSetting[lvlnumber].EnvironemtnObjects[i].SetActive(true);
        }
        //for (int i = 0; i < MyLevelSetting[lvlnumber].HelpArrowsPosition.Length - 1; i++)
        //{
        //    MyLevelSetting[lvlnumber].HelpArrowsPosition[i].SetActive(true);
        //}

        if (MyLevelSetting[lvlnumber].isAllieyPresent)
        {
            
            Alliey.transform.position = MyLevelSetting[lvlnumber].AllieyPosition.transform.position;
            Alliey.transform.rotation = MyLevelSetting[lvlnumber].AllieyPosition.transform.rotation;
            Alliey.SetActive(true);
        }

        if (MyLevelSetting[lvlnumber].isFightActivate)
        {
            for (int i = 0; i <= MyLevelSetting[lvlnumber].FightObjects.Length - 1; i++)
            {
                MyLevelSetting[lvlnumber].FightObjects[i].SetActive(true);
                MyLevelSetting[lvlnumber].FightObjects[i].transform.localPosition = MyLevelSetting[lvlnumber].FightObjectPosition[i].transform.localPosition;
                MyLevelSetting[lvlnumber].FightObjects[i].transform.localRotation = MyLevelSetting[lvlnumber].FightObjectPosition[i].transform.localRotation;

            }

        }
    }
    public void SwitchGhostToNormal()
    {
        icecreamMan.transform.position = icecreamManGhost.transform.position;
        icecreamMan.transform.rotation = icecreamManGhost.transform.rotation;
        icecreamManGhost.SetActive(false);
        icecreamMan.SetActive(true);
    }
}


[System.Serializable]
public class LevelSetting
{
    [Header("Level Time")]
    public float LevelTime;

    [Header("Player Position")]
    public GameObject PlayerPos;


    [Header("Finding Objects Level")]
    public bool isFindObjects;
    public GameObject[] Objects;
    public GameObject[] EnvironemtnObjects;
    [Header("Waypoints of Enemy")]
    public GameObject wayPoint;
    [Header("Canvas Button of Collected item")]
    public GameObject OpenButton;
    [Header("JumpScares Setting")]
    public bool isJumpScars;
    public GameObject[] JumpScars;

    [Header("Fight Settings")]
    public bool isFightActivate;
    public GameObject[] FightObjects;
    public GameObject[] FightObjectPosition;

    [Header("Allies Settings")]
    public bool isAllieyPresent;
    public GameObject AllieyPosition;

    [Header("Helping Arrow Positions")]
    public GameObject[] HelpingArrows;
    public GameObject[] HelpArrowsPosition;
    public Vector3[] HelpingArrowAnimatePositions;

}
