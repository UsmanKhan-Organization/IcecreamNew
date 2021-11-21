using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCoins : MonoBehaviour {

    public Text coinText;
    int score;
    public void OnEnable()
    {
        
    }

    // Use this for initialization

    void Start () {
        
        score = PlayerPrefs.GetInt("score");
        coinText.text = "" + score;
    }
	
	// Update is called once per frame
	void Update () {
      //  if (IAPManager.instance.coins> score)
      //  {
       //     score = IAPManager.instance.coins;
       //     PlayerPrefs.SetInt("score", score);
       //     coinText.text = "" + score;
            
      //  }
	}


}
