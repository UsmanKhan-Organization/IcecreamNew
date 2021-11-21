using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public GameObject Light;

    // Start is called before the first frame update
    void Start()
    {
        LightningManager();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LightningManager()
    {
        int i = Random.Range(1,10);
        if(i<=5)
            StartCoroutine(LightningSystem());
        else
            StartCoroutine(LightningSystemDoubleLight());
    }

    public IEnumerator LightningSystem()
    {
        float OnTime = Random.Range(1f,20f);
        float OffTime = Random.Range(0.1f, 0.3f);
        yield return new WaitForSeconds(OnTime);
        {
            Light.SetActive(true);
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.Thunder2);
        }
           
        yield return new WaitForSeconds(OffTime);
             Light.SetActive(false);

        LightningManager();
       

    }

    public IEnumerator LightningSystemDoubleLight()
    {
        float OnTime = Random.Range(1f, 20f);
        float OffTime = Random.Range(0.1f, 0.3f);
        yield return new WaitForSeconds(OnTime);
        {
            Light.SetActive(true);
            SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.Thunder);
        }

        yield return new WaitForSeconds(OffTime);
            Light.SetActive(false);

        yield return new WaitForSeconds(1);
        {
            Light.SetActive(true);
           
        }

        yield return new WaitForSeconds(OffTime);
        Light.SetActive(false);
        LightningManager();


    }
}
