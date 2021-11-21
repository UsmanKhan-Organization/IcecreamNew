using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelection : MonoBehaviour {

    private GameObject[] weaponsList;
    private int index;

	// Use this for initialization
	void Start () {
        weaponsList = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            weaponsList[i] = transform.GetChild(i).gameObject;
        }

        foreach(GameObject go in weaponsList)
        {
            go.SetActive(false);
        }

        if (weaponsList[0])
            weaponsList[0].SetActive(true);
	}
	
    public void ToggleLeft()
    {
        weaponsList[index].SetActive(false);

        index--;
        if (index < 0)
            index = weaponsList.Length - 1;

        weaponsList[index].SetActive(true);
    }

    public void ToggleRight()
    {
        weaponsList[index].SetActive(false);

        index++;
        if (index == weaponsList.Length)
            index = 0;

        weaponsList[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("WeaponSelected", index);
        SceneManager.LoadScene("LevelSelection");
    }
}
