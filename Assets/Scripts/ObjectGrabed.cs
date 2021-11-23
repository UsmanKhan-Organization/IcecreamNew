using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectGrabed : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LeveComplete()
    {
        UiManager.Instance.OnLevelCompleted.Invoke();

    }
    public void ItemPressed()
    {

        if (PlayerManager.instance.grabed && GameManager.Instance.SelectedLevel == 7)
        {
            // PlayerManager.instance.OpenAbleObject.GetComponent<Animator>().enabled = true;
            // PlayerManager.instance.OpenAbleObject.GetComponent<AudioSource>().enabled = true;
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            GamePlayManager.instance.vanDoor.GetComponent<BoxCollider>().enabled = true;

            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 3.0f);

        }

        //if (PlayerManager.instance.grabed && GameManager.Instance.SelectedLevel == 3)
        //{
        //PlayerManager.instance.OpenAbleObject.GetComponent<Animator>().SetTrigger("free");
        //PlayerManager.instance.OpenAbleObject.GetComponent<AudioSource>().enabled = false;
        //PlayerManager.instance.OpenAbleObject.transform.GetChild(PlayerManager.instance.OpenAbleObject.transform.childCount - 1).gameObject.SetActive(false);
        // UiManager.Instance.KidDialogueShow();
        //ZombieHandlerScript.instance.agent.isStopped = true;
        // Invoke("LeveComplete", 8.0f);
        // SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.grab);
        //}

        //if (GameManager.Instance.SelectedLevel == 7)
        //{
        //    print("sfds");
        //    GamePlayManager.instance.SwitchGhostToNormal();
        //    UiManager.Instance.EnableNightMode();
        //    SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.grab);
        //}
        if (PlayerManager.instance.grabed && GameManager.Instance.SelectedLevel == 9)
        {
            // PlayerManager.instance.OpenAbleObject.GetComponent<Animator>().enabled = true;
            // PlayerManager.instance.OpenAbleObject.GetComponent<AudioSource>().enabled = true;
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.finish);
            GamePlayManager.instance.garageButton.GetComponent<BoxCollider>().enabled = true;
            GamePlayManager.instance.garageWall.SetActive(false);

            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 3.0f);

        }
        if (!PlayerManager.instance.grabed && GameManager.Instance.SelectedLevel == 10)
        {
            // PlayerManager.instance.OpenAbleObject.GetComponent<Animator>().enabled = true;
            // PlayerManager.instance.OpenAbleObject.GetComponent<AudioSource>().enabled = true;
            GamePlayManager.instance.StartCoroutine(GamePlayManager.instance.Delay());
            PlayerManager.instance.grabed = true;

            // Debug.Log("LEVEL UP");
            // Invoke("LeveComplete", 3.0f);

        }
        if (PlayerManager.instance.grabed && GameManager.Instance.SelectedLevel == 13)
        {
            PlayerManager.instance.OpenAbleObject.GetComponent<Animator>().enabled = true;
            PlayerManager.instance.OpenAbleObject.GetComponent<AudioSource>().enabled = true;

            Debug.Log("LEVEL UP");
            Invoke("LeveComplete", 3.0f);

        }
        this.gameObject.SetActive(false);
    }
    

}
