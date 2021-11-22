using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timelines : MonoBehaviour
{
    public GameObject sCene1, sCene2, sCene3;
    public GameObject sTone;
    public Animator sCeneKidAnim; 

    public GameObject[] cutScene;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.SelectedLevel == 1)
        {
            GamePlayManager.instance.canVas.SetActive(false);
            GamePlayManager.instance.icecreamMan.SetActive(true);
            cutScene[0].SetActive(true);
            sCene1.SetActive(true);
            StartCoroutine(Scene1Delay(2.2f));

        }
        else if (GameManager.Instance.SelectedLevel == 2)
        {
            cutScene[1].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(7));

        }
        else if (GameManager.Instance.SelectedLevel == 3)
        {
            cutScene[2].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(5));
        }
        else if (GameManager.Instance.SelectedLevel == 4)
        {
            cutScene[1].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(5));

        }
        else if (GameManager.Instance.SelectedLevel == 5)
        {
            cutScene[2].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(11));
        }
        else if (GameManager.Instance.SelectedLevel == 6)
        {
            cutScene[1].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(11));

        }
        else if (GameManager.Instance.SelectedLevel == 7)
        {
            cutScene[2].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(7));
        }
        else if (GameManager.Instance.SelectedLevel == 8)
        {
            cutScene[1].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(7));

        }
        else if (GameManager.Instance.SelectedLevel == 9)
        {
            cutScene[2].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(7));
        }
        else if (GameManager.Instance.SelectedLevel == 10)
        {
            cutScene[2].SetActive(true);
            StartCoroutine(CutSceneDelayandOFF(11));
        }
    }
    IEnumerator CutSceneDelayandOFF(int Delay)
    {
        yield return new WaitForSeconds(Delay);
        if(cutScene[1].activeInHierarchy)
        {
            cutScene[1].SetActive(false);
        }
        else if(cutScene[2].activeInHierarchy)
        {
            cutScene[2].SetActive(false);
        }
        else if(cutScene[3].activeInHierarchy)
        {
            cutScene[3].SetActive(false);
        }
        else if(cutScene[4].activeInHierarchy)
        {
            cutScene[4].SetActive(false);
        }
        else if(cutScene[5].activeInHierarchy)
        {
            cutScene[5].SetActive(false);
        }
        else if(cutScene[6].activeInHierarchy)
        {
            cutScene[6].SetActive(false);
        }
        else if(cutScene[7].activeInHierarchy)
        {
            cutScene[7].SetActive(false);
        }
        else if(cutScene[8].activeInHierarchy)
        {
            cutScene[8].SetActive(false);
        }
        else if(cutScene[9].activeInHierarchy)
        {
            cutScene[9].SetActive(false);
        }
        else if(cutScene[10].activeInHierarchy)
        {
            cutScene[10].SetActive(false);
        }
        GamePlayManager.instance.canVas.SetActive(true);
        
    }


    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Scene1Delay(float time)
    {
        yield return new WaitForSeconds(time);
        if (sCene1.activeInHierarchy)
        {
            sCene1.SetActive(false);
            sCene2.SetActive(true);
            sCeneKidAnim.SetTrigger("throw");
            StartCoroutine(Stone(2));
        }
    }
    IEnumerator Scene2Delay(float time)
    {
        yield return new WaitForSeconds(time);
        if (sCene2.activeInHierarchy)
        {
            GamePlayManager.instance.icecreamMan.SetActive(false);
            sCene2.SetActive(false);
            sCene3.SetActive(true);
            StartCoroutine(Scene3Delay(5));

            // GamePlayManager.instance.canVas.SetActive(true);
        }
    }
    IEnumerator Scene3Delay(float time)
    {
        yield return new WaitForSeconds(time);
        if (sCene3.activeInHierarchy)
        {
            sCene3.SetActive(false);
            GamePlayManager.instance.canVas.SetActive(true);
        }
    }
    IEnumerator Stone(float bTime)
    {
        yield return new WaitForSeconds(bTime);
        sTone.SetActive(true);
        StartCoroutine(Scene2Delay(2.8f));
    }
}
