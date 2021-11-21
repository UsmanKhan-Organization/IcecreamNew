
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour
{
    [TextArea(7, 7)]
    public string[] ObjectiveDescriptions;
    public Text ObjDesText;

    public Text _text;

    public float letterPause;
    public GameObject OkButton, pauseButton;
    public GameObject buttonJump, buttonRun;
    private string message;

    public static ObjectiveHandler Instance;
    string story;
    void Awake()
    {
        if (Instance == null)
            Instance = this;

        story = ObjectiveDescriptions[GameManager.Instance.SelectedLevel - 1];
        _text.text = "";

        // TODO: add optional delay when to start
    }

    void Start()
    {
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            _text.text += c;
            yield return new WaitForSeconds(0.125f);
        }
    }
    public void OkButtonClick()
    {
        if (GameManager.Instance.SelectedLevel == 1)
        {
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.grab);
            UiManager.Instance.LevelCompleteScreen.SetActive(true);
            // PlayerManager.instance.levelCompleteCheck = true;
            // Debug.Log("LEVEL UP");
            // Invoke("LeveComplete", 2.0f);
        }
        else
        {

            buttonJump.SetActive(true);
            buttonRun.SetActive(true);
            pauseButton.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (ControlFreak2.CF2Input.GetButtonDown("Fire1"))
        {
            StopAllCoroutines();
            OkButton.SetActive(true);
            _text.text = ObjectiveDescriptions[GameManager.Instance.SelectedLevel];
        }
    }




    private void ObjText()
    {

        OkButton.SetActive(true);
        _text.text = ObjectiveDescriptions[GameManager.Instance.SelectedLevel - 1];
    }

}
