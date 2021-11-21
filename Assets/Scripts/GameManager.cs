using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour {

    public static GameManager Instance = null;

    [Header("Game Settings")]
    public GameData GData = null;

    [Header("Level Selected")]
    public int SelectedLevel = 1;
    private void Start()
    {
        //SelectedLevel = PlayerPrefs.GetInt("SelectedLevel");
        //if (SelectedLevel <= 0)
        //{
        //    SelectedLevel = 1;
        //}
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }






}
