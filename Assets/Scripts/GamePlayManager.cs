using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    public LevelSetting[] MyLevelSetting;
    public GameObject Alliey;
    //public GameObject Arrow;
    public GameObject Player, cutScene8, cutScene9,cutScene10,cutScene11,cutScene12,cutScene13,cutScene14, canVas, garageDoor,garageDoor2;

    public GameObject TimerObject, icecreamMan,icecreamManGhost;
    public GameObject[] cutscene, scenes;

    public GameObject objectPos, jewelleryDoor, level2WalletPos, level6WalletPos, level9WalletPos;
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
        if(GameManager.Instance.SelectedLevel == 1)
        {
            cutscene[0].SetActive(true);
            StartCoroutine(Scene2());

        }
        else if(GameManager.Instance.SelectedLevel == 2)
        {
            MyLevelSetting[1].Objects[0].transform.position = level2WalletPos.transform.position;
             cutscene[1].SetActive(true);
             StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 3)
        {
            cutscene[2].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 4)
        {
            cutscene[3].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 5)
        {
            cutscene[4].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 6)
        {
            MyLevelSetting[5].Objects[0].transform.position = level6WalletPos.transform.position;
            cutscene[5].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 7)
        {
            cutscene[6].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 8)
        {
            cutscene[7].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 9)
        {
            MyLevelSetting[8].Objects[0].transform.position = level9WalletPos.transform.position;
            // garageDoor.SetActive(false);
            // garageDoor2.SetActive(false);
            cutscene[8].SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 10)
        {
            garageDoor.SetActive(false);
            cutScene10.SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 11)
        {
            cutScene11.SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 12)
        {
            cutScene12.SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        else if(GameManager.Instance.SelectedLevel == 13)
        {
            cutScene13.SetActive(true);
            StartCoroutine(CutsceneDelay());
        }
        if(GameManager.Instance.SelectedLevel == 14)
        {
            MyLevelSetting[13].Objects[0].transform.position = objectPos.transform.position;
            canVas.SetActive(true);
        }
        if(GameManager.Instance.SelectedLevel == 15)
        {
            jewelleryDoor.SetActive(false);
            cutScene14.SetActive(true);
            StartCoroutine(CutsceneDelay());
        }

    }
    IEnumerator Cutscene1Delay()
    {
        yield return new WaitForSeconds(7);
        if(scenes[0].activeInHierarchy)
        {
            scenes[0].SetActive(false);
            scenes[1].SetActive(true);
            canVas.SetActive(true);
        }
    }
    IEnumerator Scene2()
    {
        yield return new WaitForSeconds(5);
        if(scenes[0].activeInHierarchy)
        {
            scenes[0].SetActive(false);
            scenes[1].SetActive(true);
            StartCoroutine(Scene3());
        }
    }
    IEnumerator Scene3()
    {
        yield return new WaitForSeconds(5);
        if(scenes[1].activeInHierarchy)
        {
            scenes[1].SetActive(false);
            scenes[2].SetActive(true);
            StartCoroutine(Scene4());
        }
    }
    IEnumerator Scene4()
    {
        yield return new WaitForSeconds(5);
        if(scenes[2].activeInHierarchy)
        {
            scenes[2].SetActive(false);
            scenes[3].SetActive(true);
            StartCoroutine(Scene5());

        }
    }
    IEnumerator Scene5()
    {
        yield return new WaitForSeconds(5);
        if(scenes[3].activeInHierarchy)
        {
            cutscene[0].SetActive(false);
            canVas.SetActive(true);
        }
    }
    IEnumerator CutsceneDelay()
    {
        yield return new WaitForSeconds(10);
        if(cutscene[0].activeInHierarchy)
        {
            cutscene[0].SetActive(false);
        }
        else if(cutscene[1].activeInHierarchy)
        {
            cutscene[1].SetActive(false);
        }
        else if(cutscene[2].activeInHierarchy)
        {
            cutscene[2].SetActive(false);
        }
        else if(cutscene[3].activeInHierarchy)
        {
            cutscene[3].SetActive(false);
        }
        else if(cutscene[4].activeInHierarchy)
        {
            cutscene[4].SetActive(false);
        }
        else if(cutscene[5].activeInHierarchy)
        {
            cutscene[5].SetActive(false);
        }
        else if(cutscene[6].activeInHierarchy)
        {
            cutscene[6].SetActive(false);
        }
        else if(cutscene[7].activeInHierarchy)
        {
            cutscene[7].SetActive(false);
        }
        else if(cutscene[8].activeInHierarchy)
        {
            garageDoor.SetActive(true);
            cutscene[8].SetActive(false);
        }
        else if(cutScene10.activeInHierarchy)
        {
            cutScene10.SetActive(false);
            garageDoor2.SetActive(false);
            garageDoor.SetActive(true);
        }
        else if(cutScene11.activeInHierarchy)
        {
            cutScene11.SetActive(false);
        }
        else if(cutScene12.activeInHierarchy)
        {
            cutScene12.SetActive(false);
        }
        else if(cutScene13.activeInHierarchy)
        {
            cutScene13.SetActive(false);
        }
        else if(cutScene14.activeInHierarchy)
        {
            cutScene14.SetActive(false);
        }
        canVas.SetActive(true);
    }
    public void OffCutscene()
    {
        cutScene8.SetActive(false);
    }
    IEnumerator ManEnableDelay()
    {
        yield return new WaitForSeconds(10);
        icecreamMan.SetActive(true);
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
