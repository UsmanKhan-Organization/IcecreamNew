using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpenRespectiveDoor : MonoBehaviour {

    public GameObject[] Doors;
    public Vector3[] DoorOpenPositions;

    private bool check = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!check)
        {
            check = true;
            opendoors();
        }
    }

    void opendoors()
    {
        SoundManager.Instance.PlayEffect(AudioClipsSource.Instance.openDoor);

        for (int i = 0; i < Doors.Length; i++)
        {
            Doors[i].transform.DORotate(DoorOpenPositions[i], 1.5f);
            // Doors[i].transform.DOLocalMove(DoorOpenPositions[i], 1.5f);
        }
    }

}
