using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{



    public bool GrabCheck = false, dropItem = false, grabed = false;
    public int objectstoGrab = 0;
    public GameObject level4Objects;

    public GameObject GrabButton, Kidlevel10, grabButtonLevel10;



    public static PlayerManager instance;
    public Text totalbeans;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //first level is selected
        if (GamePlayManager.instance.lvlnumber == 0)
        {
            //Torch.SetActive(false);
            //Hand.SetActive(false);
        }
        else
        {
            //Torch.SetActive(true);
            //Hand.SetActive(true);

        }
        if (GameManager.Instance.SelectedLevel == 7)
        {
            grabed = true;
        }
        objectstoGrab = GamePlayManager.instance.MyLevelSetting[GamePlayManager.instance.lvlnumber].Objects.Length;

        Debug.Log("TOtal objects to grab" + objectstoGrab);
    }


    public bool levelCompleteCheck = false;

    public void GrabButtonPressed(GameObject obj)
    {
        if (obj != null)
        {
            objectstoGrab -= 1;
            Destroy(obj);
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.grab);
        }
        if (obj && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 1)
        {
            grabed = true;

        }
        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 2)
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);


        }
        // if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 3)
        // {
        //     print("magic key");
        //     grabed = true;
        //     OpenIceCreamDoor.instance.CanOpenDoor = true;
        // }

        //    if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 5)
        //{
        //    levelCompleteCheck = true;
        //    Debug.Log("LEVEL UP");
        //    Invoke("LeveComplete", 2.0f);


        //}

        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 6)
        {
            // UiManager.Instance.EnableNightMode();
            // GamePlayManager.instance.SwitchGhostToNormal();
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 3.0f);

        }
        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 7)
        {
            // UiManager.Instance.showFireButton();
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 8)
        {
            Debug.Log("Cone PickedUp = true");
            grabed = true;
            // level4Objects.SetActive(true);
        }
        if (obj && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 9)
        {

            grabed = true;

        }
        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 10)
        {
            print("magic key");
            grabed = true;
            Kidlevel10.GetComponent<Animator>().SetTrigger("free");
            // OpenIceCreamDoor.instance.CanOpenDoor = true;
        }
        if (obj && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 13)
        {

            grabed = true;

        }
        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 14)
        {
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);


        }
        if (objectstoGrab <= 0 && !levelCompleteCheck && GameManager.Instance.SelectedLevel == 15)
        {
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);


        }
        itemtoGrab = null;
        Debug.Log("objects to grab remaining" + objectstoGrab);

    }

    public void LeveComplete()
    {
        UiManager.Instance.OnLevelCompleted.Invoke();

    }

    public void GameOver()
    {
        UiManager.Instance.OnLevelFailed.Invoke();
        totalbeans.text = "";
    }
    private bool collisionCheck = false;
    public GameObject itemtoGrab, OpenAbleObject;

    private void OnCollisionEnter(Collision collision)
    {


    }

    void OnTriggerEnter(Collider other)
    {

        //if (other.gameObject.tag == "Usable" && !collisionCheck)
        //{
        //    print("123fasdssd");
        //    collisionCheck = true;
        //    GrabCheck = true;
        //    grabed = true;
        //    itemtoGrab = other.gameObject;

        //}
        if (GameManager.Instance.SelectedLevel == 3 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 4 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 5 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 8 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 10 && other.gameObject.tag == "Finish" && grabed)
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 11 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 12 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish   );
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }
        if (GameManager.Instance.SelectedLevel == 14 && other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.grab);
            levelCompleteCheck = true;
            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 2.0f);

        }

        if (other.gameObject.tag == "OpenAbleObject" && grabed)
        {
            GamePlayManager.instance.MyLevelSetting[GameManager.Instance.SelectedLevel - 1].OpenButton.SetActive(true);
            OpenAbleObject = other.gameObject;
        }
        if (other.gameObject.tag == "Kid")
        {
            GamePlayManager.instance.MyLevelSetting[GameManager.Instance.SelectedLevel - 1].OpenButton.SetActive(true);
        }



    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OpenAbleObject" && grabed)
        {
            GamePlayManager.instance.MyLevelSetting[GameManager.Instance.SelectedLevel - 1].OpenButton.SetActive(false);
            OpenAbleObject = null;
        }
        // if(other.gameObject.tag == "Kid")
        // {
        //     grabButtonLevel10.SetActive(false);
        // }



    }


}
