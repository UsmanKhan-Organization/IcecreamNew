using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

    public float timeLeft = 10.0f;
    public Text text;
    [HideInInspector]
    public bool clock;
    private float mins;
    private float secs;

    public Image BatteryImg;

    public bool LevelCompleteOrFailed = false;
    public float decrementImgVal = 0.0f;
    public static TimerScript Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        decrementImgVal = (1 / timeLeft);
        //timeLeft = GamePlayHandler.SharedInstance.GameLevel[GameManager.Instance.SelectedLevel - 1].LevelTime;

    }



    void Update()
    {
        if (!LevelCompleteOrFailed)
        {
            if (timeLeft > 0 && clock == false)
            {
                clock = true;
                StartCoroutine(Wait());
            }
        }
       
      
       

    }

    IEnumerator Wait()
    {
        timeLeft -= 1;
        //UpdateTimer();
        DecreaseBattery();
        yield return new WaitForSeconds(1);
        if (BatteryImg.fillAmount <= 0)
        {
            UiManager.Instance.OnLevelFailed.Invoke();
        }
        else
        {
            clock = false;
        }
        //Debug.Log("Time Left is " + timeLeft);
        
      
    }
    
    public void DecreaseBattery()
    {
        //print(BatteryImg.fillAmount);
        BatteryImg.fillAmount -= decrementImgVal;
        if(BatteryImg.fillAmount<=0.7f && BatteryImg.fillAmount >= 0.4f)
        {
            BatteryImg.color = Color.yellow;
        }

        if (BatteryImg.fillAmount < 0.4f){
            BatteryImg.color = Color.red;

        }

    }


    void UpdateTimer()
    {
        int min = Mathf.FloorToInt(timeLeft / 60);
        int sec = Mathf.FloorToInt(timeLeft % 60);
        text.GetComponent<UnityEngine.UI.Text>().text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
