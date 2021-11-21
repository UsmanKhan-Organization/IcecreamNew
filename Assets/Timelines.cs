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


    // Update is called once per frame
    void Update()
    {

    }
}
