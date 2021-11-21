using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {

    public string[] ObjectiveDescriptions;
    public Text ObjDesText;

    public Text _text;


    public float letterPause;
    public GameObject OkButton;
    private string message;

    public static ObjectiveHandler Instance;

   void Awake()
    {
        if (Instance == null)
            Instance = this;

    }

     void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StopAllCoroutines();
            OkButton.SetActive(true);
            _text.text = ObjectiveDescriptions[GameManager.Instance.SelectedLevel];
        }
    }

    // Use this for initialization
    public void WriteText(string msg)
    {
        message = msg;
        _text.text = "";
        ObjText();
        Time.timeScale = 0;
    }

    private IEnumerator TypeText()
    {
        foreach (var letter in message)
        {
           // _text.text = ObjectiveDescriptions[GameManager.Instance.SelectedLevel];
          //  _text.text += letter;
            //SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.typewritterEfect);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        OkButton.SetActive(true);
        
    }

    private void ObjText()
    {
        OkButton.SetActive(true);
        _text.text = ObjectiveDescriptions[GameManager.Instance.SelectedLevel-1];
    }

}
